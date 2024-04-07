using ClosedXML.Excel;
using TDGPGasReader.DTOs.DataManager.UseCases.Save;
using TDGPGasReader.Model.Excel.interfaces;

namespace TDGPGasReader.Model.Excel
{
    public class ExcelManagerModel : IExcelManagerModel
    {
        public ExcelManagerModel() { }

        public void SaveDataToExcel(string filePath, List<ExtractedDataToSaveDTO> dataExamples)
        {
            // Criando um novo documento Excel
            using (var workbook = new XLWorkbook())
            {
                // Adicionando uma planilha ao documento
                var worksheet = workbook.Worksheets.Add("Sample Data");

                // Adicionando cabeçalhos de coluna
                worksheet.Cell("A1").Value = "Measurement Type";
                worksheet.Cell("B1").Value = "Timestamp";
                worksheet.Cell("C1").Value = "Temperature [ºC]";
                worksheet.Cell("D1").Value = "Dissolved Gas Pressure [mbar]";
                worksheet.Cell("E1").Value = "Supply voltage [volts]";
                worksheet.Cell("F1").Value = "ATM";
                worksheet.Cell("G1").Value = "Concentração de N2";
                worksheet.Cell("H1").Value = "Massa de Nitrogênio";
                worksheet.Cell("I1").Value = "TDG (%)";

                int currentRow = 2;
                foreach (var data in dataExamples)
                {
                    // Escrevendo dados na linha
                    worksheet.Cell(currentRow, 1).Value = data.MeasurementType;
                    worksheet.Cell(currentRow, 2).Value = data.Timestamp;
                    worksheet.Cell(currentRow, 3).Value = data.SensorTemperature;
                    worksheet.Cell(currentRow, 4).Value = data.PressureMBar;
                    worksheet.Cell(currentRow, 5).Value = data.SupplyVoltage;
                    worksheet.Cell(currentRow, 6).Value = data.Atm;
                    worksheet.Cell(currentRow, 7).Value = data.N2Concentration;
                    worksheet.Cell(currentRow, 8).Value = data.NitrogenMass;
                    worksheet.Cell(currentRow, 9).Value = data.TdgPercentual;
                    currentRow++;
                }

                // Ajustando o tamanho das colunas para se adequar ao conteúdo
                worksheet.Columns().AdjustToContents();

                // Salvando o arquivo
                workbook.SaveAs(filePath);
            }
        }
    }
}
