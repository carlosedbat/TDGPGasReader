namespace TDGPGasReader.Model.HenryLawConstants
{
    using TDGPGasReader.Enums;
    using TDGPGasReader.Model.HenryLawConstants.Interfaces;

    public class HenryLawConstantsModel : IHenryLawConstantsModel
    {
        private Dictionary<EnumGasesNoOxigenio, Dictionary<int, double>> _constants;

        public HenryLawConstantsModel()
        {
            // Inicialize o dicionário com os valores da tabela fornecida.
            _constants = new Dictionary<EnumGasesNoOxigenio, Dictionary<int, double>>
            {
                {
                    EnumGasesNoOxigenio.Argon,
                    new Dictionary<int, double> { { 0, 0.000217 }, { 10, 0.000237 }, { 20, 0.000259 }, { 30, 0.000397 }, { 40, 0.000436 }, { 50, 0.000479 } }
                },
                { 
                    EnumGasesNoOxigenio.Acetylene,
                    new Dictionary<int, double> { { 0, 0.072 }, { 10, 0.096 }, { 20, 0.121 }, { 30, 0.146 }, { 40, 0.194 }, { 50, 0.251 } } 
                },
                { 
                    EnumGasesNoOxigenio.CarbonDioxide,
                    new Dictionary<int, double> { { 0, 0.073 }, { 10, 0.105 }, { 20, 0.148 }, { 30, 0.194 }, { 40, 0.251 }, { 50, 0.321 } } 
                },
                { 
                    EnumGasesNoOxigenio.Ethane,
                    new Dictionary<int, double> { { 0, 1.26 }, { 10, 1.89 }, { 20, 2.63 }, { 30, 3.42 }, { 40, 4.23 }, { 50, 5.00 } } 
                },
                { 
                    EnumGasesNoOxigenio.Helium,
                    new Dictionary<int, double> { { 0, 12.9 }, { 10, 12.6 }, { 20, 12.5 }, { 30, 12.4 }, { 40, 12.1 }, { 50, 11.5 } } 
                },
                { 
                    EnumGasesNoOxigenio.Hydrogen,
                    new Dictionary<int, double> { { 0, 5.79 }, { 10, 6.36 }, { 20, 6.83 }, { 30, 7.29 }, { 40, 7.51 }, { 50, 7.65 } } 
                },
                { 
                    EnumGasesNoOxigenio.HydrogenSulfide,
                    new Dictionary<int, double> { { 0, 0.0268 }, { 10, 0.0367 }, { 20, 0.0483 }, { 30, 0.0609 }, { 40, 0.0745 }, { 50, 0.0884 } } 
                },
                { 
                    EnumGasesNoOxigenio.Methane,
                    new Dictionary<int, double> { { 0, 2.24 }, { 10, 2.97 }, { 20, 3.76 }, { 30, 4.49 }, { 40, 5.20 }, { 50, 5.77 } } 
                },
                { 
                    EnumGasesNoOxigenio.Nitrogen,
                    new Dictionary<int, double> { { 0, 5.29 }, { 10, 6.687 }, { 20, 8.04 }, { 30, 9.24 }, { 40, 10.4 }, { 50, 11.3 } } 
                },
                { 
                    EnumGasesNoOxigenio.Oxygen,
                    new Dictionary<int, double> { { 0, 2.55 }, { 10, 3.27 }, { 20, 4.01 }, { 30, 4.75 }, { 40, 5.35 }, { 50, 5.88 } } 
                },
                { 
                    EnumGasesNoOxigenio.Ozone,
                    new Dictionary<int, double> { { 0, 0.194 }, { 10, 0.248 }, { 20, 0.376 }, { 30, 0.598 }, { 40, 1.20 }, { 50, 2.74 } } 
                }
            };
        }

        private double InterpolateConstant(EnumGasesNoOxigenio gas, double temperature)
        {
            var temperatures = _constants[gas].Keys.ToList();
            temperatures.Sort();

            int lowerIndex = temperatures.FindLastIndex(t => t <= temperature);
            int upperIndex = temperatures.FindIndex(t => t >= temperature);

            if (lowerIndex == -1 || upperIndex == -1)
            {
                throw new ArgumentOutOfRangeException("Temperature is out of the range of available data.");
            }

            if (lowerIndex == upperIndex) // A temperatura exata está disponível
            {
                return _constants[gas][temperatures[lowerIndex]];
            }

            // Obtenha os valores mais próximos para a interpolação
            int lowerBoundTemp = temperatures[lowerIndex];
            int upperBoundTemp = temperatures[upperIndex];
            double lowerBoundConstant = _constants[gas][lowerBoundTemp];
            double upperBoundConstant = _constants[gas][upperBoundTemp];

            // Interpole linearmente entre os dois
            double interpolatedConstant = lowerBoundConstant + (upperBoundConstant - lowerBoundConstant) * ((temperature - lowerBoundTemp) / (upperBoundTemp - lowerBoundTemp));

            return interpolatedConstant;
        }

        public double GetHenryConstant(EnumGasesNoOxigenio gas, double temperature)
        {
            // Se a temperatura exata está disponível, retorne-a diretamente
            if (_constants[gas].ContainsKey((int)temperature))
            {
                return _constants[gas][(int)temperature];
            }
            else
            {
                // Senão, faça a interpolação
                return InterpolateConstant(gas, temperature);
            }
        }
    }
}
