namespace TDGPGasReader.Presenter.MainForm
{
    using System.ComponentModel;
    using System.IO.Ports;
    using TDGPGasReader.Consts;
    using TDGPGasReader.DTOs.DataManager.UseCases.Save;
    using TDGPGasReader.Model.DataManager.Interfaces;
    using TDGPGasReader.Model.Excel.interfaces;
    using TDGPGasReader.Presenter.MainForm.Interfaces;
    using TDGPGasReader.Views.Main.Interfaces;

    public class MainFormPresenter : IMainFormPresenter
    {
        private IForm1View _form1;
        private readonly IDataManagerModel _dataManager;
        private readonly IExcelManagerModel _excelManagerModel;

        private SerialPort serialPort1;
        private string dataBuffer = "";
        private ExtractedDataToSaveDTO _extractedData;
        private bool started = false;
        private List<ExtractedDataToSaveDTO> _extractedDataToSave;

        public MainFormPresenter(
            IDataManagerModel dataManagerModel,
            IExcelManagerModel excelManagerModel)
        {
            this._dataManager = dataManagerModel;
            this._excelManagerModel = excelManagerModel;
            this._extractedDataToSave = new List<ExtractedDataToSaveDTO>();
        }

        public void SetView(IForm1View view)
        {
            this._form1 = view;
        }

        public bool CheckSerialPortIsOpen()
        {
            return serialPort1.IsOpen;
        }

        private void PopulateSerialPortComboBox()
        {
            string[] serialAvaiables = SerialPort.GetPortNames();

            this._form1.PopulateSerialPortComboBox(serialAvaiables);
        }

        public void ConfigureSerialCommunication(IContainer components)
        {
            this.serialPort1 = new SerialPort(components);

            serialPort1.PortName = "COM9";
            serialPort1.BaudRate = 19200;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            serialPort1.Handshake = Handshake.None;

            this.InitializeSerialPort();
            this.PopulateSerialPortComboBox();
        }

        private void InitializeSerialPort()
        {
            serialPort1.DataReceived += SerialPort1_DataReceived;
        }

        public void OpenSerialCommunication(string serialPortCommunication)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = serialPortCommunication;
                    serialPort1.Open();

                    Task.Run(() => this.Aquisite());
                } else
                {
                    this._form1.ShowAlertMessage("A comunicação ja esta aberta. Feche a conexão antes de abrir uma nova!");
                }

            }
            catch (Exception ex)
            {
                this._form1.ShowErrorMessage("Erro ao abrir a porta serial: " + ex.Message);
            }
        }

        public void StartAquisition()
        {
            try
            {
                if (!this.started)
                {
                    this.started = true;
                }
            } catch (Exception ex)
            {
                this.started = false;
                this._form1.ShowErrorMessage(ex.Message);
            }
        }

        public async Task Aquisite()
        {
            try
            {
                while (serialPort1.IsOpen)
                {
                    if (this.started)
                    {
                        this._extractedDataToSave.Add(this._extractedData);
                        await Task.Delay(TimeIntervals.OneMinutInMiliSeconds);
                    }
                }
               
            }
            catch (Exception ex)
            {
                this._form1.ShowErrorMessage(ex.Message);
            }
            finally
            {
                this._extractedDataToSave.Clear();
            }
        }

        public void StopAquisition()
        {
            if (this.started)
            {
                this.started = false;

                if (this._extractedDataToSave.Any())
                {
                    string filePath = this._form1.ShowSaveFileDialog();
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        this._excelManagerModel.SaveDataToExcel(filePath, this._extractedDataToSave);
                    }
                }
            }
        }

        public void CloseSerialCommunication()
        {
            serialPort1.Close();
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

                this._extractedData = new ExtractedDataToSaveDTO();

                this._extractedData = this._dataManager.ParseDataToValues(lastCompleteLine);  // Processa a última linha completa
                string extractedDataStringed = this._dataManager.ParseDataToShowString(this._extractedData);

                this._form1.AddDataInTerminal(extractedDataStringed);

                this._form1.SetTemperature(this._extractedData.SensorTemperature);

                this._form1.SetTDGPercentual(this._extractedData.TdgPercentual);

                this._form1.SetNitrogenMass(this._extractedData.NitrogenMass);

                this._form1.SetN2Concentration(this._extractedData.N2Concentration);

                this._form1.SetATM(this._extractedData.Atm);
            }
        }
    }
}
