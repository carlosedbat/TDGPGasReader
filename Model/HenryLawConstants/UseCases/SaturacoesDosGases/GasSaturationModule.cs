
namespace TDGPGasReader.Model.HenryLawConstants.UseCases.SaturacoesDosGases
{
    using TDGPGasReader.Enums;
    using TDGPGasReader.Model.HenryLawConstants.Interfaces;

    public class GasSaturationModule : IGasSaturationModule
    {
        private static Dictionary<EnumGasesNoOxigenio, Dictionary<double, double>> saturationConcentrations;

        public GasSaturationModule()
        {
            saturationConcentrations = new Dictionary<EnumGasesNoOxigenio, Dictionary<double, double>>
            {
                {
                    EnumGasesNoOxigenio.Argon,
                    new Dictionary<double, double>
                    {
                        { 0.0, 14.621 },
                        { 1.0, 14.216 },
                        { 23.9, 8.433 },
                        { 24.0, 0.5153 }, { 24.10, 0.5143 }, { 24.20, 0.5134 }, { 24.30, 0.5125 }, { 24.40, 0.5115 },
                        { 24.50, 0.5106 }, { 24.60, 0.5096 }, { 24.70, 0.5087 }, { 24.80, 0.5078 }, { 24.90, 0.5068 },
                        { 25.0, 0.263 }, { 25.10, 0.248 },{ 25.20, 0.232 },{ 25.30, 0.217 },{ 25.40, 0.202 },
                        { 25.50, 0.187 },{ 25.60, 0.172 },{ 25.70, 0.157 },{ 25.80, 0.143 },{ 25.90, 0.128 },
                    }
                },
                {
                    EnumGasesNoOxigenio.Oxygen,
                    new Dictionary<double, double>
                    {
                        { 0.0, 14.621 },
                        { 1.0, 14.216 },
                        { 23.9, 8.433 },
                        { 24.0, 8.418 }, { 24.10, 8.402 }, { 24.20, 8.386 }, { 24.30, 8.371 }, { 24.40, 8.355 },
                        { 24.50, 8.340 }, { 24.60, 8.324 }, { 24.70, 8.309 }, { 24.80, 8.293 }, { 24.90, 8.278 },
                        { 25.0, 8.263 }, { 25.10, 8.248 },{ 25.20, 8.232 },{ 25.30, 8.217 },{ 25.40, 8.202 },
                        { 25.50, 8.187 },{ 25.60, 8.172 },{ 25.70, 8.157 },{ 25.80, 8.143 },{ 25.90, 8.128 },
                    }
                },
                {
                    EnumGasesNoOxigenio.Nitrogen,
                    new Dictionary<double, double>
                    {
                        { 0.0, 14.621 },
                        { 1.0, 14.216 },
                        { 23.9, 8.433 },
                        { 24.0, 14.032 }, { 24.10, 14.009 }, { 24.20, 13.986 }, { 24.30, 13.963 }, { 24.40, 13.940 },
                        { 24.50, 13.917 }, { 24.60, 13.895 }, { 24.70, 13.872 }, { 24.80,13.849 }, { 24.90, 13.827 },
                        { 25.0, 8.263 }, { 25.10, 8.248 },{ 25.20, 8.232 },{ 25.30, 8.217 },{ 25.40, 8.202 },
                        { 25.50, 8.187 },{ 25.60, 8.172 },{ 25.70, 8.157 },{ 25.80, 8.143 },{ 25.90, 8.128 },
                    }
                },
                {
                    EnumGasesNoOxigenio.CarbonDioxide,
                    new Dictionary<double, double>
                    {
                        { 0.0, 14.621 },
                        { 1.0, 14.216 },
                        { 23.9, 8.433 },
                        { 24.0, 0.5795 }, { 24.10, 0.5778 }, { 24.20, 0.5761 }, { 24.30, 0.5744 }, { 24.40, 0.5728 },
                        { 24.50, 0.5711 }, { 24.60, 0.5694 }, { 24.70, 0.5678 }, { 24.80, 0.5661 }, { 24.90, 0.5645 },
                        { 25.0, 0.263 }, { 25.10, 0.248 },{ 25.20, 0.232 },{ 25.30, 0.217 },{ 25.40, 0.202 },
                        { 25.50, 0.187 },{ 25.60, 0.172 },{ 25.70, 0.157 },{ 25.80, 0.143 },{ 25.90, 0.128 },
                    }
                },
            };
        }

        public double GetSaturationConcentration(EnumGasesNoOxigenio gas, double temperature)
        {
            if (temperature < 0.0)
            {
                temperature = 0.0;
            }

            if (temperature > 49.9) 
            {
                temperature = 49.9;
            }

            return saturationConcentrations[gas][Math.Round(temperature, 1)];
        }
    }
}
