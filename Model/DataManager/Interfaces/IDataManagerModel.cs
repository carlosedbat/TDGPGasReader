using TDGPGasReader.DTOs.DataManager.UseCases.Save;

namespace TDGPGasReader.Model.DataManager.Interfaces
{
    public interface IDataManagerModel
    {
        ExtractedDataToSaveDTO ParseDataToValues(string data);

        string ParseDataToShowString(ExtractedDataToSaveDTO extractedDataToSaveDTO);
    }
}
