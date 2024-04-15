namespace TDGPGasReader.Model.DataManager
{
    using System.Globalization;
    using TDGPGasReader.DTOs.DataManager.UseCases.Save;
    using TDGPGasReader.Model.DataManager.Interfaces;
    using TDGPGasReader.Model.GasCalculator.Interfaces;

    public class DataManagerModel : IDataManagerModel
    {
        private readonly IGasCalculatorModel _gasCalculatorModel;

        public DataManagerModel(IGasCalculatorModel gasCalculatorModel) 
        {
            this._gasCalculatorModel = gasCalculatorModel;
        }

        public ExtractedDataToSaveDTO ParseDataToValues(string data)
        {
            try
            {
                ExtractedDataToSaveDTO extractedDataToSaveDTO = new ExtractedDataToSaveDTO();
                // Remove o espaço inicial antes de dividir, se existir.
                data = data.Trim();

                // Divide a string em partes usando a vírgula como separador
                string[] parts = data.Split(',');

                // Extrai cada parte para a variável correspondente
                extractedDataToSaveDTO.MeasurementType = parts[0].Substring(0, 1);  // Obtém o 'P'
                //int year = SafeParseInt(parts[0].Substring(2));     // Converte para inteiro o ano, que começa na posição 2 da primeira parte
                //int month = SafeParseInt(parts[1]);
                //int day = SafeParseInt(parts[2]);
                //int hour = SafeParseInt(parts[3]);
                //int minute = SafeParseInt(parts[4]);
                //int second = SafeParseInt(parts[5]);

                extractedDataToSaveDTO.Timestamp = DateTime.Now;

                extractedDataToSaveDTO.SensorTemperature = SafeParseDouble(parts[6]);

                extractedDataToSaveDTO.PressureMBar = SafeParseDouble(parts[7]);

                extractedDataToSaveDTO.SupplyVoltage = SafeParseDouble(parts[8]);

                extractedDataToSaveDTO.Atm = this._gasCalculatorModel.CalculateATM(extractedDataToSaveDTO.PressureMBar);

                extractedDataToSaveDTO.N2Concentration = this._gasCalculatorModel.CalculateTdgConcentration(extractedDataToSaveDTO.Atm, extractedDataToSaveDTO.SensorTemperature);

                extractedDataToSaveDTO.NitrogenMass = this._gasCalculatorModel.CalculateTDGMass(extractedDataToSaveDTO.Atm, extractedDataToSaveDTO.SensorTemperature);

                extractedDataToSaveDTO.TdgPercentual = this._gasCalculatorModel.CalculateTDGPercentage(extractedDataToSaveDTO.Atm, extractedDataToSaveDTO.SensorTemperature);

                return extractedDataToSaveDTO;
            }
            catch (Exception e) {
                throw new Exception(e.Message);
            }

        }

       public string ParseDataToShowString(ExtractedDataToSaveDTO extractedDataToSaveDTO)
        {
            try
            {
                string dataStringed = $"{extractedDataToSaveDTO.MeasurementType}, {extractedDataToSaveDTO.Timestamp}, " +
                    $"{extractedDataToSaveDTO.PressureMBar}, {extractedDataToSaveDTO.SupplyVoltage}, " +
                    $"{extractedDataToSaveDTO.Atm}, {extractedDataToSaveDTO.N2Concentration}, " +
                    $"{extractedDataToSaveDTO.NitrogenMass}, {extractedDataToSaveDTO.TdgPercentual}";

                return dataStringed;
            } 
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }


        private int SafeParseInt(string input)
        {
            return int.TryParse(input, out int result) ? result : 0;
        }

        private double SafeParseDouble(string input)
        {
            // Tenta converter usando a cultura en-US que usa o ponto como separador decimal
            bool success = double.TryParse(input, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double result);
            return success ? result : 0.0;
        }
    }
}
