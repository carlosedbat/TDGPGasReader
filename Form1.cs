namespace TDGPGasReader
{
    using System.IO.Ports;

    public partial class Form1 : Form
    {
        private SerialPort serialPort1;

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

        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadExisting();
            Invoke(new MethodInvoker(delegate
            {
                txtTerminal.AppendText(data);
            }));
        }
    }
}