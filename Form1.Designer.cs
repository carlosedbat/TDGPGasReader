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
            groupBox2 = new GroupBox();
            labelConcentracaoN2 = new Label();
            groupBox3 = new GroupBox();
            labelMassaDeNitrogenio = new Label();
            groupBox4 = new GroupBox();
            labelPorcentagemN2 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // txtTerminal
            // 
            txtTerminal.Location = new Point(330, 379);
            txtTerminal.Multiline = true;
            txtTerminal.Name = "txtTerminal";
            txtTerminal.ScrollBars = ScrollBars.Vertical;
            txtTerminal.Size = new Size(590, 178);
            txtTerminal.TabIndex = 0;
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(101, 534);
            txtCommand.Name = "txtCommand";
            txtCommand.Size = new Size(208, 23);
            txtCommand.TabIndex = 1;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 57);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(110, 23);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Conectar";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // cmbSerialPort
            // 
            cmbSerialPort.FormattingEnabled = true;
            cmbSerialPort.Location = new Point(144, 57);
            cmbSerialPort.Name = "cmbSerialPort";
            cmbSerialPort.Size = new Size(165, 23);
            cmbSerialPort.TabIndex = 3;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 532);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(83, 25);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelATM);
            groupBox1.Location = new Point(330, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(143, 68);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "ATM";
            // 
            // labelATM
            // 
            labelATM.AutoSize = true;
            labelATM.Location = new Point(60, 32);
            labelATM.Name = "labelATM";
            labelATM.Size = new Size(22, 15);
            labelATM.TabIndex = 9;
            labelATM.Text = "0.0";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(labelConcentracaoN2);
            groupBox2.Location = new Point(479, 25);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(143, 68);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Concentração de N2";
            // 
            // labelConcentracaoN2
            // 
            labelConcentracaoN2.AutoSize = true;
            labelConcentracaoN2.Location = new Point(62, 32);
            labelConcentracaoN2.Name = "labelConcentracaoN2";
            labelConcentracaoN2.Size = new Size(22, 15);
            labelConcentracaoN2.TabIndex = 10;
            labelConcentracaoN2.Text = "0.0";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(labelMassaDeNitrogenio);
            groupBox3.Location = new Point(628, 25);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(143, 68);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Massa de Nitrogênio";
            // 
            // labelMassaDeNitrogenio
            // 
            labelMassaDeNitrogenio.AutoSize = true;
            labelMassaDeNitrogenio.Location = new Point(59, 32);
            labelMassaDeNitrogenio.Name = "labelMassaDeNitrogenio";
            labelMassaDeNitrogenio.Size = new Size(22, 15);
            labelMassaDeNitrogenio.TabIndex = 11;
            labelMassaDeNitrogenio.Text = "0.0";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(labelPorcentagemN2);
            groupBox4.Location = new Point(777, 25);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(143, 68);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "% de N2";
            // 
            // labelPorcentagemN2
            // 
            labelPorcentagemN2.AutoSize = true;
            labelPorcentagemN2.Location = new Point(62, 32);
            labelPorcentagemN2.Name = "labelPorcentagemN2";
            labelPorcentagemN2.Size = new Size(22, 15);
            labelPorcentagemN2.TabIndex = 12;
            labelPorcentagemN2.Text = "0.0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 569);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnSend);
            Controls.Add(cmbSerialPort);
            Controls.Add(btnConnect);
            Controls.Add(txtCommand);
            Controls.Add(txtTerminal);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
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
        private GroupBox groupBox2;
        private Label labelATM;
        private Label labelConcentracaoN2;
        private GroupBox groupBox3;
        private Label labelMassaDeNitrogenio;
        private GroupBox groupBox4;
        private Label labelPorcentagemN2;
    }
}