namespace TDGPGasReader
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            bindingSource1 = new BindingSource(components);
            bindingSource2 = new BindingSource(components);
            txtTerminal = new TextBox();
            txtCommand = new TextBox();
            btnConnect = new Button();
            cmbSerialPort = new ComboBox();
            btnSend = new Button();
            groupBox1 = new GroupBox();
            labelATM = new Label();
            labelConcentracaoN2 = new Label();
            groupBox3 = new GroupBox();
            labelMassaDeNitrogenio = new Label();
            groupBox4 = new GroupBox();
            labelPorcentagemN2 = new Label();
            buttonStart = new Button();
            buttonStop = new Button();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            panel4 = new Panel();
            labelConnectionStatus = new Label();
            labelReadingStatus = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // txtTerminal
            // 
            txtTerminal.Location = new Point(206, 274);
            txtTerminal.Multiline = true;
            txtTerminal.Name = "txtTerminal";
            txtTerminal.ScrollBars = ScrollBars.Vertical;
            txtTerminal.Size = new Size(720, 178);
            txtTerminal.TabIndex = 0;
            // 
            // txtCommand
            // 
            txtCommand.Enabled = false;
            txtCommand.Location = new Point(23, 534);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(161, 23);
            txtCommand.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 174);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(172, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cmbSerialPort
            // 
            cmbSerialPort.FormattingEnabled = true;
            cmbSerialPort.Location = new Point(12, 135);
            cmbSerialPort.Name = "cmbSerialPort";
            cmbSerialPort.Size = new Size(172, 23);
            cmbSerialPort.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Enabled = false;
            btnSend.Location = new Point(23, 503);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(161, 25);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelATM);
            groupBox1.Location = new Point(83, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(143, 68);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "ATM";
            // 
            // labelATM
            // 
            labelATM.AutoSize = true;
            labelATM.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelATM.Location = new Point(30, 23);
            labelATM.Name = "labelATM";
            labelATM.Size = new Size(84, 30);
            labelATM.TabIndex = 9;
            labelATM.Text = "0.00000";
            // 
            // labelConcentracaoN2
            // 
            labelConcentracaoN2.AutoSize = true;
            labelConcentracaoN2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelConcentracaoN2.Location = new Point(30, 12);
            labelConcentracaoN2.Name = "labelConcentracaoN2";
            labelConcentracaoN2.Size = new Size(84, 30);
            labelConcentracaoN2.TabIndex = 10;
            labelConcentracaoN2.Text = "0.00000";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(labelMassaDeNitrogenio);
            groupBox3.Location = new Point(381, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(143, 68);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Massa de Nitrogênio";
            // 
            // labelMassaDeNitrogenio
            // 
            labelMassaDeNitrogenio.AutoSize = true;
            labelMassaDeNitrogenio.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelMassaDeNitrogenio.Location = new Point(27, 23);
            labelMassaDeNitrogenio.Name = "labelMassaDeNitrogenio";
            labelMassaDeNitrogenio.Size = new Size(84, 30);
            labelMassaDeNitrogenio.TabIndex = 11;
            labelMassaDeNitrogenio.Text = "0.00000";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(labelPorcentagemN2);
            groupBox4.Location = new Point(530, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(143, 68);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "% de N2";
            // 
            // labelPorcentagemN2
            // 
            labelPorcentagemN2.AutoSize = true;
            labelPorcentagemN2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            labelPorcentagemN2.Location = new Point(26, 23);
            labelPorcentagemN2.Name = "labelPorcentagemN2";
            labelPorcentagemN2.Size = new Size(96, 30);
            labelPorcentagemN2.TabIndex = 12;
            labelPorcentagemN2.Text = "000.00 %";
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(12, 239);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 9;
            buttonStart.Text = "Iniciar";
            buttonStart.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(109, 239);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 23);
            buttonStop.TabIndex = 10;
            buttonStop.Text = "Parar";
            buttonStop.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 44);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 12;
            label1.Text = "Concentração de N2";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelConcentracaoN2);
            panel1.Location = new Point(235, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(140, 67);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(buttonStop);
            panel2.Controls.Add(cmbSerialPort);
            panel2.Controls.Add(buttonStart);
            panel2.Controls.Add(btnConnect);
            panel2.Controls.Add(txtCommand);
            panel2.Controls.Add(btnSend);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 569);
            panel2.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(groupBox4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(200, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(738, 86);
            panel3.TabIndex = 15;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 74);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(54, 111);
            label2.Name = "label2";
            label2.Size = new Size(89, 21);
            label2.TabIndex = 4;
            label2.Text = "Porta Serial";
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(labelReadingStatus);
            panel4.Controls.Add(labelConnectionStatus);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(200, 534);
            panel4.Name = "panel4";
            panel4.Size = new Size(738, 35);
            panel4.TabIndex = 16;
            // 
            // labelConnectionStatus
            // 
            labelConnectionStatus.AutoSize = true;
            labelConnectionStatus.Location = new Point(126, 11);
            labelConnectionStatus.Name = "labelConnectionStatus";
            labelConnectionStatus.Size = new Size(82, 15);
            labelConnectionStatus.TabIndex = 0;
            labelConnectionStatus.Text = "Desconectado";
            // 
            // labelReadingStatus
            // 
            labelReadingStatus.AutoSize = true;
            labelReadingStatus.Location = new Point(630, 11);
            labelReadingStatus.Name = "labelReadingStatus";
            labelReadingStatus.Size = new Size(82, 15);
            labelReadingStatus.TabIndex = 1;
            labelReadingStatus.Text = "Desconectado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 11);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 2;
            label3.Text = "Status da Conexão";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(517, 11);
            label4.Name = "label4";
            label4.Size = new Size(94, 15);
            label4.TabIndex = 3;
            label4.Text = "Status da Leitura";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 569);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(txtTerminal);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private BindingSource bindingSource1;
        private BindingSource bindingSource2;
        private TextBox txtTerminal;
        private TextBox txtCommand;
        private Button btnConnect;
        private ComboBox cmbSerialPort;
        private Button btnSend;
        private GroupBox groupBox1;
        private Label labelATM;
        private Label labelConcentracaoN2;
        private GroupBox groupBox3;
        private Label labelMassaDeNitrogenio;
        private GroupBox groupBox4;
        private Label labelPorcentagemN2;
        private Button buttonStart;
        private Button buttonStop;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel3;
        private Panel panel4;
        private Label label4;
        private Label label3;
        private Label labelReadingStatus;
        private Label labelConnectionStatus;
    }
}