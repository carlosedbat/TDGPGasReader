namespace TDGPGasReader.Presenter.MainForm
{
    using System.ComponentModel;
    using System.IO.Ports;
    using TDGPGasReader.Consts;
    using TDGPGasReader.DTOs.DataManager.UseCases.Save;
    using TDGPGasReader.Enums;
    using TDGPGasReader.Model.DataManager.Interfaces;
    using TDGPGasReader.Model.Excel.interfaces;
    using TDGPGasReader.Presenter.MainForm.Interfaces;
    using TDGPGasReader.Utils.Conversores;
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

        private bool esperandoCabecalho = false;
        private bool tentarReconectar = true;
        private int tentativasReconexao = 0;
        private const int MaxTentativasReconexao = 10;

        private string mensagemEspecialBuffer = "";
        private System.Timers.Timer timerParaMensagemEspecial;

        public MainFormPresenter(
            IDataManagerModel dataManagerModel,
            IExcelManagerModel excelManagerModel)
        {
            this._dataManager = dataManagerModel;
            this._excelManagerModel = excelManagerModel;
            this._extractedDataToSave = new List<ExtractedDataToSaveDTO>();

            timerParaMensagemEspecial = new System.Timers.Timer(1500) { AutoReset = false };
            timerParaMensagemEspecial.Elapsed += (sender, e) => ImprimirMensagemEspecial();
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

        public async void OpenSerialCommunication(string serialPortCommunication)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = serialPortCommunication;
                    serialPort1.Open();
                    await Task.Delay(3000);
                    this.EnviarComandoBin(".");
                    await Task.Delay(2000);
                    this.EnviarComandoBin(".");
                    await Task.Delay(2000);
                    this.EnviarComandoBin("1");

                    this._form1.SetConnectionStatus(EnumConnectionStatus.Conectado);
                    this._form1.SetReadingStatus(EnumReadingStatus.Aguardando);

                    Task.Run(() => this.Aquisite());
                } else
                {
                    this._form1.ShowAlertMessage("A comunicação ja esta aberta. Feche a conexão antes de abrir uma nova!");
                }

            }
            catch (Exception ex)
            {
                this._form1.SetConnectionStatus(EnumConnectionStatus.Desconectado);
                this._form1.SetReadingStatus(EnumReadingStatus.Desconectado);
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
                    this._form1.SetReadingStatus(EnumReadingStatus.Lendo);
                    this._form1.LimparGrafico();
                }
            } catch (Exception ex)
            {
                this.started = false;
                this._form1.SetReadingStatus(EnumReadingStatus.Aguardando);
                this._form1.ShowErrorMessage(ex.Message);
            }
        }

        public async Task Aquisite()
        {
            try
            {
                while (serialPort1.IsOpen)
                {
                    if (this.started && this._extractedData is not null)
                    {
                        this._extractedDataToSave.Add(this._extractedData);
                        this._form1.AddTdgOnGraph(this._extractedData.Timestamp, (this._extractedData.TdgPercentual * 100));
                        this._form1.AddTemperatureOnGraph(this._extractedData.Timestamp, this._extractedData.SensorTemperature);
                        await Task.Delay(TimeIntervals.OneMinutInMiliSeconds);
                    }
                }
               
            }
            catch (Exception ex)
            {
                this._form1.SetReadingStatus(EnumReadingStatus.Aguardando);
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
                this._form1.SetReadingStatus(EnumReadingStatus.Aguardando);

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

        public async void CloseSerialCommunication()
        {
            this.EnviarComandoBin("2");
            await Task.Delay(1500);
            serialPort1.Close();
            this._form1.SetConnectionStatus(EnumConnectionStatus.Desconectado);
            this._form1.SetReadingStatus(EnumReadingStatus.Desconectado);
        }
        private void ImprimirMensagemEspecial()
        {
            if (!string.IsNullOrEmpty(mensagemEspecialBuffer))
            {
                this._form1.AddDataInTerminal(mensagemEspecialBuffer);
                mensagemEspecialBuffer = ""; // Limpar o buffer após imprimir
            }
        }


        private async void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            dataBuffer += serialPort1.ReadExisting();  // Concatena os novos dados no buffer existente


            // Verifique se o buffer inicia ou termina com "*", redefina o timer se sim.
            if (!dataBuffer.StartsWith("P 2"))
            {
                mensagemEspecialBuffer += dataBuffer; // Concatena com o buffer de mensagens especiais
                dataBuffer = ""; // Limpar o buffer de dados normal

                // Reinicia ou inicia o timer
                timerParaMensagemEspecial.Stop();
                timerParaMensagemEspecial.Start();
            }
            else if (dataBuffer.Contains("\n"))  // Verifica se existe uma nova linha completa
            {
                // Separa as linhas no buffer
                var lines = dataBuffer.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string lastCompleteLine = lines.Last();  // Pega a última linha completa
                dataBuffer = "";  // Limpa o buffer

                if (lastCompleteLine.Contains("NaN") || lastCompleteLine.Contains("Stop"))
                {
                    // Caso a string contenha "NaN", tenta reconectar
                    IniciarReconexao();
                    await Task.Run(() => VerificarReconexao());
                }
                else if (esperandoCabecalho && lastCompleteLine.Contains("Sensor on."))
                {
                    // Se estiver esperando pelo cabeçalho e ele for recebido
                    esperandoCabecalho = false;
                    Enviar1(); // Envia comando para iniciar amostragem
                }
                else
                {
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

        private async void IniciarReconexao()
        {
            Enviar2(); // Envia comando para parar amostragem
            esperandoCabecalho = true; // Define que está esperando pelo cabeçalho de resposta
            await Task.Delay(1000);
            Enviar1();
        }

        public void EnviarComando(string comando)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(comando); // Envia comando para o dispositivo
            }
        }

        public void EnviarComandoBin(string command)
        {
            ComandoParaByte converter = new ComandoParaByte();
            byte[] comando = converter.GetComandoByte(command);

            //switch (command)
            //{
            //    case "1":
            //        comando = new byte[] { 0x31 }; // ASCII '1'
            //        break;
            //    case "2":
            //        comando = new byte[] { 0x32 }; // ASCII '2'
            //        break;
            //    case "3":
            //        comando = new byte[] { 0x33 }; // ASCII '3'
            //        break;
            //    case "4":
            //        comando = new byte[] { 0x34 }; // ASCII '4'
            //        break;
            //    case "5":
            //        comando = new byte[] { 0x35 }; // ASCII '5'
            //        break;
            //    case "6":
            //        comando = new byte[] { 0x36 }; // ASCII '6'
            //        break;
            //    case "s":
            //        comando = new byte[] { 0x73 }; // ASCII 's'
            //        break;
            //    case "t":
            //        comando = new byte[] { 0x74 }; // ASCII 't'
            //        break;
            //    case "r":
            //        comando = new byte[] { 0x72 }; // ASCII 'r'
            //        break;
            //    case ".":
            //       comando = new byte[] { 0x1B }; // Byte que representa o caractere '.'
            //        break;
            //    default:
            //        comando = System.Text.Encoding.ASCII.GetBytes(command); // Default ASCII encoding for other inputs
            //        break;
            //}

            if (serialPort1.IsOpen)
            {
                serialPort1.Write(comando, 0, comando.Length); // Envia o byte para o dispositivo
            }
        }


        private void VerificarReconexao()
        {
            while (tentarReconectar && tentativasReconexao < MaxTentativasReconexao)
            {
                // Tenta reconectar
                IniciarReconexao();
                tentativasReconexao++;

                Thread.Sleep(5000); // 5 segundos
            }
        }

        public void Enviar1()
        {
            byte[] comando = new byte[] { 0x31 }; // Byte que representa o caractere '.'
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(comando, 0, comando.Length); // Envia o byte para o dispositivo
            }
        }

        public void Enviar2()
        {
            byte[] comando = new byte[] { 0x32 }; // Byte que representa o caractere '.'
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(comando, 0, comando.Length); // Envia o byte para o dispositivo
            }
        }

        public void EnviarPoint()
        {
            byte[] comando = new byte[] { 0x1B }; // Byte que representa o caractere '.'
            if (serialPort1.IsOpen)
            {
                serialPort1.Write(comando, 0, comando.Length); // Envia o byte para o dispositivo
            }
        }
    }
}
