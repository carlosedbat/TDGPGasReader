namespace TDGPGasReader
{
    using System.Globalization;
    using System.IO.Ports;
    using TDGPGasReader.Presenter.MainForm.Interfaces;
    using TDGPGasReader.Views.Main.Interfaces;

    public partial class Form1 : Form, IForm1View
    {
        private IMainFormPresenter _form1Presenter;
        private SerialPort serialPort1;
        private string dataBuffer = "";
        private bool started = false;
        private List<string> dataRecords = new List<string>();

        public Form1()
        {
            InitializeComponent();
            serialPort1 = new SerialPort(components);
        }
        public void SetPresenter(IMainFormPresenter presenter)
        {
            _form1Presenter = presenter;
            this._form1Presenter.ConfigureSerialCommunication(components);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void PopulateSerialPortComboBox(string[] portsAvaiable)
        {
            cmbSerialPort.Items.Clear();
            foreach (string s in portsAvaiable)
            {
                cmbSerialPort.Items.Add(s);
            }
            if (cmbSerialPort.Items.Count > 0) cmbSerialPort.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._form1Presenter.CheckSerialPortIsOpen())
                {
                    this._form1Presenter.CloseSerialCommunication();
                    btnConnect.Text = "Connect";
                }
                else
                {
                    this._form1Presenter.OpenSerialCommunication(this.cmbSerialPort.SelectedItem.ToString());
                    btnConnect.Text = "Disconnect";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.WriteLine(txtCommand.Text);
                txtCommand.Clear();
            }
            else
            {
                MessageBox.Show("Serial port is not connected.");
            }
        }

        //private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        //{
        //    dataBuffer += serialPort1.ReadExisting();  // Concatena os novos dados no buffer existente
        //    if (dataBuffer.Contains("\n"))  // Verifica se existe uma nova linha completa
        //    {
        //        // Separa as linhas no buffer
        //        var lines = dataBuffer.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        //        string lastCompleteLine = lines.Last();  // Pega a última linha completa
        //        dataBuffer = "";  // Limpa o buffer

        //        if (this.started)
        //        {
        //            this.ParseDataToValues(lastCompleteLine);  // Processa a última linha completa

        //        }
        //        Invoke(new MethodInvoker(delegate
        //        {
        //            txtTerminal.AppendText(lastCompleteLine + Environment.NewLine);  // Atualiza o terminal com a última linha
        //        }));
        //    }
        //}

        //private int SafeParseInt(string input)
        //{
        //    return int.TryParse(input, out int result) ? result : 0;
        //}

        //private double SafeParseDouble(string input)
        //{
        //    // Tenta converter usando a cultura en-US que usa o ponto como separador decimal
        //    bool success = double.TryParse(input, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out double result);
        //    return success ? result : 0.0;
        //}

        //public void ParseDataToValues(string data)
        //{
        //    try
        //    {
        //        // Remove o espaço inicial antes de dividir, se existir.
        //        data = data.Trim();

        //        // Divide a string em partes usando a vírgula como separador
        //        string[] parts = data.Split(',');

        //        // Extrai cada parte para a variável correspondente
        //        string measurementType = parts[0].Substring(0, 1);  // Obtém o 'P'
        //        int year = SafeParseInt(parts[0].Substring(2));     // Converte para inteiro o ano, que começa na posição 2 da primeira parte
        //        int month = SafeParseInt(parts[1]);
        //        int day = SafeParseInt(parts[2]);
        //        int hour = SafeParseInt(parts[3]);
        //        int minute = SafeParseInt(parts[4]);
        //        int second = SafeParseInt(parts[5]);
        //        double temperature = SafeParseDouble(parts[6]);
        //        double pressure = SafeParseDouble(parts[7]);
        //        double supplyVoltage = SafeParseDouble(parts[8]);

        //        double atm = this.SetATM(pressure);
        //        double convertedN2Pressure = this.SetN2Concentration(atm);
        //        double nitrogenMass = this.SetNitrogenMass(convertedN2Pressure);
        //        double n2Percentual = this.SetN2Percentual(nitrogenMass);
        //        this.SetTemperature(temperature);
        //    }
        //    catch (Exception e) { Console.WriteLine(e.ToString()); }

        //}
        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowAlertMessage(string message)
        {
            MessageBox.Show(message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string ShowSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx"; // Configura o filtro para arquivos Excel
            saveFileDialog.Title = "Save as Excel File"; // Título do diálogo
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName; // Retorna o caminho completo do arquivo caso o usuário clique em 'Salvar'
            }
            return null; // Retorna null caso o usuário cancele
        }

        public void SetATM(double atm)
        {
            if (labelATM.InvokeRequired)
            {
                labelATM.Invoke(new MethodInvoker(delegate
                {
                    labelATM.Text = atm.ToString("F6"); // F5 para formatar com 5 casas decimais
                }));
            }
            else
            {
                labelATM.Text = atm.ToString("F6");
            }
        }

        public void SetN2Concentration(double n2Concentration)
        {
            if (labelConcentracaoN2.InvokeRequired)
            {
                labelConcentracaoN2.Invoke(new MethodInvoker(delegate
                {
                    labelConcentracaoN2.Text = n2Concentration.ToString("F6");
                }));
            }
            else
            {
                labelConcentracaoN2.Text = n2Concentration.ToString("F6");
            }
        }


        public void SetNitrogenMass(double nitrogenMass)
        {
            if (labelMassaDeNitrogenio.InvokeRequired)
            {
                labelMassaDeNitrogenio.Invoke(new MethodInvoker(delegate
                {
                    labelMassaDeNitrogenio.Text = nitrogenMass.ToString("F6");
                }));
            }
            else
            {
                labelMassaDeNitrogenio.Text = nitrogenMass.ToString("F6");
            }
        }


        public void SetTDGPercentual(double tdgPercentual)
        {
            string n2PercentualStringed = (tdgPercentual * 100).ToString("F2") + '%';

            if (labelPorcentagemN2.InvokeRequired)
            {
                labelPorcentagemN2.Invoke(new MethodInvoker(delegate
                {
                    labelPorcentagemN2.Text = n2PercentualStringed;
                }));
            }
            else
            {
                labelPorcentagemN2.Text = n2PercentualStringed;
            }
        }

        public void SetTemperature(double temperature)
        {
            if (labelTemperature.InvokeRequired)
            {
                labelTemperature.Invoke(new MethodInvoker(delegate
                {
                    labelTemperature.Text = $"{temperature} °C";
                }));
            }
            else
            {
                labelTemperature.Text = $"{temperature} °C";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this._form1Presenter.StartAquisition();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this._form1Presenter.StopAquisition();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        public void AddDataInTerminal(string stringedDataToTerminal)
        {
            Invoke(new MethodInvoker(delegate
            {
                txtTerminal.AppendText(stringedDataToTerminal + Environment.NewLine);  // Atualiza o terminal com a última linha
            }));
        }
    }
}