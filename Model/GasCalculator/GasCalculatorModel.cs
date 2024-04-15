using TDGPGasReader.Enums;
using TDGPGasReader.Model.GasCalculator.Interfaces;
using TDGPGasReader.Model.HenryLawConstants.Interfaces;

namespace TDGPGasReader.Model.GasCalculator
{
    public class GasCalculatorModel : IGasCalculatorModel
    {
        // Constantes de exemplo para a pressão atmosférica ao nível do mar e os pesos moleculares dos gases
        private const double AtmosphericPressure = 1013.25;  // mbar
        private const double MolecularWeightNitrogen = 28.014; // g/mol
        private const double MolecularWeightOxygen = 31.998; // g/mol
        private const double MolecularWeightCO2 = 44.01; // g/mol
        private const double MolecularWeightArgon = 39.948; // g/mol


        private readonly IHenryLawConstantsModel _hanryLawConstantsModel;
        private readonly IGasSaturationModule _hanrySaturationModule;

        public GasCalculatorModel(
            IHenryLawConstantsModel hanryLawConstantsModel,
            IGasSaturationModule gasSaturationModule) 
        {
            this._hanryLawConstantsModel = hanryLawConstantsModel;
            this._hanrySaturationModule = gasSaturationModule;
        }

        public double CalculateConcentration(double pressureMbar, EnumGasesNoOxigenio gas, double temperature)
        {
            double henryConstant = _hanryLawConstantsModel.GetHenryConstant(gas, temperature);
            double pressureAtm = pressureMbar / AtmosphericPressure;
            double concentrationMolar = pressureAtm * henryConstant;
            return concentrationMolar;
        }

        public double CalculateTdgConcentration(double pressure, double temperature)
        {
            double concentrationNitrogen = CalculateConcentration(pressure, EnumGasesNoOxigenio.Nitrogen, temperature);
            double concentrationOxygen = CalculateConcentration(pressure, EnumGasesNoOxigenio.Oxygen, temperature);
            double concentrationCO2 = CalculateConcentration(pressure, EnumGasesNoOxigenio.CarbonDioxide, temperature);
            double concentrationArgon = CalculateConcentration(pressure, EnumGasesNoOxigenio.Argon, temperature);

            return concentrationNitrogen + concentrationOxygen + concentrationCO2 + concentrationArgon;
        }
        private double GetMolecularWeight(EnumGasesNoOxigenio gas)
        {
            // Mapeie cada enum de gás para seu peso molecular
            switch (gas)
            {
                case EnumGasesNoOxigenio.Nitrogen:
                    return MolecularWeightNitrogen;
                case EnumGasesNoOxigenio.Oxygen:
                    return MolecularWeightOxygen;
                case EnumGasesNoOxigenio.CarbonDioxide:
                    return MolecularWeightCO2;
                case EnumGasesNoOxigenio.Argon:
                    return MolecularWeightArgon;

                default:
                    throw new ArgumentException("Peso molecular desconhecido para o gás fornecido.");
            }
        }


        public double CalculateTDGMass(double pressureMbar, double temperature)
        {
            double massNitrogen = CalculateConcentration(pressureMbar * 0.78, EnumGasesNoOxigenio.Nitrogen, temperature); // 78% do ar é nitrogênio
            massNitrogen = massNitrogen * GetMolecularWeight(EnumGasesNoOxigenio.Nitrogen);

            double massOxygen = CalculateConcentration(pressureMbar * 0.21, EnumGasesNoOxigenio.Oxygen, temperature); // 21% do ar é oxigênio
            massOxygen = massOxygen * GetMolecularWeight(EnumGasesNoOxigenio.Oxygen);

            double massCO2 = CalculateConcentration(pressureMbar * 0.0004, EnumGasesNoOxigenio.CarbonDioxide, temperature); // 0.04% do ar é CO2
            massCO2 = massCO2 * GetMolecularWeight(EnumGasesNoOxigenio.CarbonDioxide);

            double massArgon = CalculateConcentration(pressureMbar * 0.0093, EnumGasesNoOxigenio.Argon, temperature); // 0.93% do ar é argônio
            massArgon = massArgon * GetMolecularWeight(EnumGasesNoOxigenio.Argon);

            // Somar todas as massas para obter o TDG total, ajuste as frações conforme necessário
            return massNitrogen + massOxygen + massCO2 + massArgon;
        }

        private double GetSaturation(EnumGasesNoOxigenio gas, double temperature)
        {
            // Suponha que temos uma função que retorna a concentração de saturação a 100% para o gás na temperatura dada
            // Você precisará preencher esta função com a lógica apropriada com base nos dados de saturação que você possui
            return _hanrySaturationModule.GetSaturationConcentration(gas, temperature);
        }

        public double CalculateTDGPercentage(double pressureMbar, double temperature)
        {
            double tdgMass = CalculateTDGMass(pressureMbar, temperature);

            // Assumir que temos a saturação de 100% para cada gás na temperatura dada
            double saturationNitrogen = GetSaturation(EnumGasesNoOxigenio.Nitrogen, temperature);
            double saturationOxygen = GetSaturation(EnumGasesNoOxigenio.Oxygen, temperature);
            double saturationCO2 = GetSaturation(EnumGasesNoOxigenio.CarbonDioxide, temperature);
            double saturationArgon = GetSaturation(EnumGasesNoOxigenio.Argon, temperature);

            // A soma das saturações dos gases dá a saturação total (100%)
            double totalSaturation = saturationNitrogen + saturationOxygen + saturationCO2 + saturationArgon;

            // O percentual de TDG é a razão entre o TDG medido e o valor de saturação total, multiplicado por 100
            double tdgPercentage = (tdgMass / totalSaturation) * 100;
            return tdgPercentage;
        }

        public double CalculateATM(double pressure)
        {
            //double constant = 0.00098923;

            //double atm = pressure * constant;

            double atm = pressure / AtmosphericPressure;

            return atm;
        }

        public double CalculateN2Concentration(double atm, double temperature)
        {
            double conversionFactor = this._hanryLawConstantsModel.GetHenryConstant(EnumGasesNoOxigenio.Nitrogen, temperature);

            double convertedPressure = atm * conversionFactor;

            return convertedPressure;
        }


        public double CalculateNitrogenMass(double n2Concentration)
        {
            double constant = 28.01;

            double nitrogenMass = n2Concentration * constant;

            return nitrogenMass;
        }


        public double CalculateTDGPercentual(double nitrogenMass)
        {
            double constant = 0.000258;

            double n2Percentual = 1 - ((nitrogenMass - constant) / constant);

            return n2Percentual;
        }
    }
}
