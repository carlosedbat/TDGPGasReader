namespace TDGPGasReader
{
    using System.Globalization;
    using System.IO.Ports;

    public partial class Form1 : Form
    {
        private SerialPort serialPort1;
        private string dataBuffer = "";
        private bool started = false;

        public Form1()
        {
            InitializeComponent();
            serialPort1 = new System.IO.Ports.SerialPort(components);
            SetSerialPort();
            InitializeSerialPort();
            PopulateSerialPortComboBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetSerialPort()
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

        private void PopulateSerialPortComboBox()
        {
            cmbSerialPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                cmbSerialPort.Items.Add(s);
            }
            if (cmbSerialPort.Items.Count > 0) cmbSerialPort.SelectedIndex = 0;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                    btnConnect.Text = "Connect";
                }
                else
                {
                    serialPort1.PortName = cmbSerialPort.SelectedItem.ToString();
                    serialPort1.Open();
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
        //    string data = serialPort1.ReadExisting();
        //    this.ParseDataToValues(data);
        //    Invoke(new MethodInvoker(delegate
        //    {
        //        txtTerminal.AppendText(data);
        //    }));
        //}

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            dataBuffer += serialPort1.ReadExisting();  // Concatena os novos dados no buffer existente
            if (dataBuffer.Contains("\n"))  // Verifica se existe uma nova linha completa
            {
                // Separa as linhas no buffer
                var lines = dataBuffer.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string lastCompleteLine = lines.Last();  // Pega a última linha completa
                dataBuffer = "";  // Limpa o buffer

                if (this.started)
                {
                    this.ParseDataToValues(lastCompleteLine);  // Processa a última linha completa

                }
                Invoke(new MethodInvoker(delegate
                {
                    txtTerminal.AppendText(lastCompleteLine + Environment.NewLine);  // Atualiza o terminal com a última linha
                }));
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

        public void ParseDataToValues(string data)
        {
            try
            {
                // Remove o espaço inicial antes de dividir, se existir.
                data = data.Trim();

                // Divide a string em partes usando a vírgula como separador
                string[] parts = data.Split(',');

                // Extrai cada parte para a variável correspondente
                string measurementType = parts[0].Substring(0, 1);  // Obtém o 'P'
                int year = SafeParseInt(parts[0].Substring(2));     // Converte para inteiro o ano, que começa na posição 2 da primeira parte
                int month = SafeParseInt(parts[1]);
                int day = SafeParseInt(parts[2]);
                int hour = SafeParseInt(parts[3]);
                int minute = SafeParseInt(parts[4]);
                int second = SafeParseInt(parts[5]);
                double temperature = SafeParseDouble(parts[6]);
                double pressure = SafeParseDouble(parts[7]);
                double supplyVoltage = SafeParseDouble(parts[8]);

                double atm = this.SetATM(pressure);
                double convertedN2Pressure = this.SetN2Concentration(atm);
                double nitrogenMass = this.SetNitrogenMass(convertedN2Pressure);
                double n2Percentual = this.SetN2Percentual(nitrogenMass);
                this.SetTemperature(temperature);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }

        }

        public double SetATM(double pressure)
        {
            double constant = 0.00098923;
            double atm = pressure * constant;

            if (labelATM.InvokeRequired)
            {
                labelATM.Invoke(new MethodInvoker(delegate
                {
                    labelATM.Text = atm.ToString("F5"); // F5 para formatar com 5 casas decimais
                }));
            }
            else
            {
                labelATM.Text = atm.ToString("F5");
            }

            return atm;
        }

        public double SetN2Concentration(double atm)
        {
            double conversionFactor = Math.Pow(10, -5);
            double convertedPressure = atm * conversionFactor;

            if (labelConcentracaoN2.InvokeRequired)
            {
                labelConcentracaoN2.Invoke(new MethodInvoker(delegate
                {
                    labelConcentracaoN2.Text = convertedPressure.ToString("F5");
                }));
            }
            else
            {
                labelConcentracaoN2.Text = convertedPressure.ToString("F5");
            }

            return convertedPressure;
        }


        public double SetNitrogenMass(double n2Concentration)
        {
            double constant = 28.01;
            double nitrogenMass = n2Concentration * constant;

            if (labelMassaDeNitrogenio.InvokeRequired)
            {
                labelMassaDeNitrogenio.Invoke(new MethodInvoker(delegate
                {
                    labelMassaDeNitrogenio.Text = nitrogenMass.ToString("F5");
                }));
            }
            else
            {
                labelMassaDeNitrogenio.Text = nitrogenMass.ToString("F5");
            }

            return nitrogenMass;
        }


        public double SetN2Percentual(double nitrogenMass)
        {
            double constant = 0.000258;
            double n2Percentual = 1 - ((nitrogenMass - constant) / constant);

            string n2PercentualStringed = (n2Percentual * 100).ToString("F2") + '%';

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

            return n2Percentual;
        }

        public void SetTemperature(double temperature)
        {
            if (labelTemperature.InvokeRequired)
            {
                labelTemperature.Invoke(new MethodInvoker(delegate
                {
                    labelTemperature.Text = temperature.ToString();
                }));
            }
            else
            {
                labelTemperature.Text = temperature.ToString() + " °C";
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.started = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            this.started = false;
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
    }
}