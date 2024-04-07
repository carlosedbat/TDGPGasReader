namespace TDGPGasReader
{
    using System.IO.Ports;
    using System.Windows.Forms.DataVisualization.Charting;
    using TDGPGasReader.Enums;
    using TDGPGasReader.Presenter.MainForm.Interfaces;
    using TDGPGasReader.Views.Main.Interfaces;

    public partial class Form1 : Form, IForm1View
    {
        private IMainFormPresenter _form1Presenter;
        private SerialPort serialPort1;
        private Series _seriesTemperature;
        private Series _seriesTdg;

        public Form1()
        {
            InitializeComponent();
            serialPort1 = new SerialPort(components);
            this.ConfigureGraph();
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

        public void SetReadingStatus(EnumReadingStatus status)
        {
            if (labelReadingStatus.InvokeRequired)
            {
                labelReadingStatus.Invoke(new MethodInvoker(delegate
                {
                    labelReadingStatus.Text = status.ToString();
                }));
            }
            else
            {
                labelReadingStatus.Text = status.ToString();
            }
        }
        public void SetConnectionStatus(EnumConnectionStatus status)
        {
            if (labelConnectionStatus.InvokeRequired)
            {
                labelConnectionStatus.Invoke(new MethodInvoker(delegate
                {
                    labelConnectionStatus.Text = status.ToString();
                }));
            }
            else
            {
                labelConnectionStatus.Text = status.ToString();
            }
        }
        
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

        private void ConfigureGraph()
        {
            // Acessar a série de Temperatura e modificar propriedades
            Series seriesTemperature = this.chart1.Series["Temperatura"];
            if (seriesTemperature != null)
            {
                seriesTemperature.ChartType = SeriesChartType.Line;
                seriesTemperature.BorderWidth = 2;
                seriesTemperature.Color = Color.Aquamarine;
                seriesTemperature.YAxisType = AxisType.Secondary; // Configura para usar o eixo Y secundário
            }

            // Acessar a série de TDG e modificar propriedades
            Series seriesTDG = this.chart1.Series["TDG"];
            if (seriesTDG != null)
            {
                seriesTDG.ChartType = SeriesChartType.Line;
                seriesTDG.BorderWidth = 2;
                seriesTDG.Color = Color.Blue;
                seriesTDG.YAxisType = AxisType.Primary; // Configura para usar o eixo Y primário
            }

            // Verificar se uma ChartArea já existe, se não, adicioná-la
            if (this.chart1.ChartAreas.Count == 0)
            {
                ChartArea chartArea = new ChartArea();
                this.chart1.ChartAreas.Add(chartArea);
                chartArea.AxisY2.Enabled = AxisEnabled.True; // Habilita o eixo Y2
                chartArea.AxisX.Title = "Tempo";  // Título do eixo X
                chartArea.AxisY.Title = "TDG";  // Título do eixo Y (para TDG)
                chartArea.AxisY2.Title = "Temperatura";  // Título do eixo Y2 (para Temperatura)
            }
        }


        public void LimparGrafico()
        {
            // Verifica se a operação de limpeza precisa ser feita na thread da UI
            if (this.chart1.InvokeRequired)
            {
                this.chart1.Invoke(new MethodInvoker(() =>
                {
                    ClearAndConfigureGraph();
                }));
            }
            else
            {
                ClearAndConfigureGraph();
            }
        }

        private void ClearAndConfigureGraph()
        {
            this.chart1.Series.Clear();  // Limpa todas as séries do gráfico
            this.ConfigureGraph();       // Reconfigura o gráfico adicionando as séries de volta
        }

        public void AddTemperatureOnGraph(DateTime xAxys, double yAxys)
        {
            Action addPointAction = () => this._seriesTemperature.Points.AddXY(xAxys, yAxys);
            ModifyGraph(addPointAction);
        }

        public void AddTdgOnGraph(DateTime xAxys, double yAxys)
        {
            Action addPointAction = () => this._seriesTdg.Points.AddXY(xAxys, yAxys);
            ModifyGraph(addPointAction);
        }

        private void ModifyGraph(Action graphModificationAction)
        {
            if (this.chart1.InvokeRequired)
            {
                this.chart1.Invoke(new MethodInvoker(graphModificationAction));
            }
            else
            {
                graphModificationAction.Invoke();
            }
        }
    }
}
