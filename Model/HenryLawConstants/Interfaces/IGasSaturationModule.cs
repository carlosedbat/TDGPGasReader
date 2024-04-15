using TDGPGasReader.Enums;

namespace TDGPGasReader.Model.HenryLawConstants.Interfaces
{
    public interface IGasSaturationModule
    {
        double GetSaturationConcentration(EnumGasesNoOxigenio gas, double temperature);
    }
}
