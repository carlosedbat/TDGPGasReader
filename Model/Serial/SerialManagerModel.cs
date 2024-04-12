namespace TDGPGasReader.Model.Serial
{
    using System.IO.Ports;
    using TDGPGasReader.DTOs.DataManager.UseCases.Save;
    using TDGPGasReader.Model.DataManager.Interfaces;
    using TDGPGasReader.Model.Serial.Interfaces;

    public class SerialManagerModel : ISerialManagerModel
    {
        private readonly IDataManagerModel _dataManager;
        private SerialPort serialPort1;
        private string dataBuffer = "";
        private bool started = false;
        public SerialManagerModel(IDataManagerModel dataManagerModel)
        {
            this._dataManager = dataManagerModel;
        }

        private void ConfigureSerialCommunication()
        {
            serialPort1.PortName = "COM9";
            serialPort1.BaudRate = 19200;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;
        }

        private void InitializeSerialPort()
        {
            serialPort1.DataReceived += SerialPort1_DataReceived;
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataBuffer += serialPort1.ReadExisting();  // Concatena os novos dados no buffer existente
            if (dataBuffer.Contains("\n"))  // Verifica se existe uma nova linha completa
            {
                // Separa as linhas no buffer
                var lines = dataBuffer.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string lastCompleteLine = lines.Last();  // Pega a última linha completa
                dataBuffer = "";  // Limpa o buffer

                ExtractedDataToSaveDTO extractedData = this._dataManager.ParseDataToValues(lastCompleteLine);  // Processa a última linha completa
                string extractedDataStringed = this._dataManager.ParseDataToShowString(extractedData);

            }
        }
    }
}
