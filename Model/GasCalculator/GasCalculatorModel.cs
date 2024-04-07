using TDGPGasReader.Model.GasCalculator.Interfaces;

namespace TDGPGasReader.Model.GasCalculator
{
    public class GasCalculatorModel : IGasCalculatorModel
    {
        public GasCalculatorModel() { }

        public double CalculateATM(double pressure)
        {
            double constant = 0.00098923;

            double atm = pressure * constant;

            return atm;
        }

        public double CalculateN2Concentration(double atm)
        {
            double conversionFactor = Math.Pow(10, -5);

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
