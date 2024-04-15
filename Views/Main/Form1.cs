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
                    //btnConnect.Text = "Connect";
                }
                else
                {
                    this._form1Presenter.OpenSerialCommunication(this.cmbSerialPort.SelectedItem.ToString());
                    //btnConnect.Text = "Disconnect";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetButomConnect(EnumConnectionButom butom)
        {
            if (btnConnect.InvokeRequired)
            {
                btnConnect.Invoke(new MethodInvoker(delegate
                {
                    btnConnect.Text = butom.ToString();
                }));
            }
            else
            {
                btnConnect.Text = butom.ToString();
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
            // Verifica e cria a série de Temperatura se necessário
            if (this.chart1.Series.IndexOf("Temperatura") == -1)
            {
                this._seriesTemperature = new Series("Temperatura")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = Color.Aquamarine,
                    YAxisType = AxisType.Secondary
                };
                this.chart1.Series.Add(this._seriesTemperature);
            }
            else
            {
                this._seriesTemperature = this.chart1.Series["Temperatura"];
            }

            // Verifica e cria a série de TDG se necessário
            if (this.chart1.Series.IndexOf("TDG") == -1)
            {
                this._seriesTdg = new Series("TDG")
                {
                    ChartType = SeriesChartType.Line,
                    BorderWidth = 2,
                    Color = Color.Blue,
                    YAxisType = AxisType.Primary
                };
                this.chart1.Series.Add(this._seriesTdg);
            }
            else
            {
                this._seriesTdg = this.chart1.Series["TDG"];
            }

            // Configura a área do gráfico, se ainda não estiver configurada
            if (this.chart1.ChartAreas.Count == 0)
            {
                var chartArea = new ChartArea();
                this.chart1.ChartAreas.Add(chartArea);
                chartArea.AxisY2.Enabled = AxisEnabled.True;
                chartArea.AxisX.Title = "Tempo";
                chartArea.AxisY.Title = "TDG";
                chartArea.AxisY2.Title = "Temperatura";

                // Configurações de linhas de grade
                chartArea.AxisX.MajorGrid.Enabled = false; // Desabilita as linhas de grade principais do eixo X
                chartArea.AxisY.MajorGrid.Enabled = false; // Desabilita as linhas de grade principais do eixo Y
                chartArea.AxisY2.MajorGrid.Enabled = false; // Desabilita as linhas de grade principais do eixo Y2

                // Formatar a data para mostrar apenas os minutos
                chartArea.AxisX.LabelStyle.Format = "hh:mm"; // Formato de hora e minuto
                chartArea.AxisX.IntervalType = DateTimeIntervalType.Minutes;
                chartArea.AxisX.Interval = 1;
            }

            if (this.chart1.ChartAreas.Count > 0)
            {
                var chartArea = this.chart1.ChartAreas[0];

                // Remover linhas de grade horizontais e verticais do eixo X e Y
                chartArea.AxisX.MajorGrid.Enabled = false;
                chartArea.AxisX.MinorGrid.Enabled = false;
                chartArea.AxisY.MajorGrid.Enabled = false;
                chartArea.AxisY.MinorGrid.Enabled = false;

                // Se você também quiser remover as linhas de grade do eixo Y secundário (Y2)
                chartArea.AxisY2.MajorGrid.Enabled = false;
                chartArea.AxisY2.MinorGrid.Enabled = false;

                // Formatar a data para mostrar apenas os minutos ou conforme necessário
                // Isso dependerá do tipo de valor que você está passando para o eixo X
                // Se estiver passando DateTime, você pode formatar como abaixo
                chartArea.AxisX.LabelStyle.Format = "hh:mm"; // Mostra apenas horas e minutos
                                                             // Se estiver passando um valor numérico, talvez você queira ajustar o formato ou a propriedade Interval
                chartArea.AxisX.IntervalType = DateTimeIntervalType.Minutes;
                chartArea.AxisX.Interval = 1;
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

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            this._form1Presenter.EnviarComandoBin(this.txtCommand.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this._form1Presenter.Enviar1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._form1Presenter.Enviar2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this._form1Presenter.EnviarPoint();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void buttonSimulator_Click(object sender, EventArgs e)
        {
            await this._form1Presenter.Simulate();
        }
    }
}
