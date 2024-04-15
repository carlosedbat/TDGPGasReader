using TDGPGasReader.Enums;

namespace TDGPGasReader.Model.HenryLawConstants.Interfaces
{
    public interface IHenryLawConstantsModel
    {
        double GetHenryConstant(EnumGasesNoOxigenio gas, double temperature);
    }
}
