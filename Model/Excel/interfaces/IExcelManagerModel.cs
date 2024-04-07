using TDGPGasReader.DTOs.DataManager.UseCases.Save;

namespace TDGPGasReader.Model.Excel.interfaces
{
    public interface IExcelManagerModel
    {
        void SaveDataToExcel(string filePath, List<ExtractedDataToSaveDTO> dataExamples);
    }
}
