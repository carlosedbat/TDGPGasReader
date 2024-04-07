﻿namespace TDGPGasReader
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
            labelATM = new Label();
            labelConcentracaoN2 = new Label();
            labelMassaDeNitrogenio = new Label();
            labelPorcentagemN2 = new Label();
            buttonStart = new Button();
            buttonStop = new Button();
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel7 = new Panel();
            label7 = new Label();
            panel6 = new Panel();
            label6 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            panel4 = new Panel();
            label4 = new Label();
            label3 = new Label();
            labelReadingStatus = new Label();
            labelConnectionStatus = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            labelTemperature = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtTerminal
            // 
            txtTerminal.Dock = DockStyle.Bottom;
            txtTerminal.Location = new Point(0, 472);
            txtTerminal.Multiline = true;
            txtTerminal.Name = "txtTerminal";
            txtTerminal.ScrollBars = ScrollBars.Vertical;
            txtTerminal.Size = new Size(938, 97);
            txtTerminal.TabIndex = 0;
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(23, 437);
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
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSend.Location = new Point(23, 406);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(161, 25);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // labelATM
            // 
            labelATM.Anchor = AnchorStyles.Bottom;
            labelATM.AutoSize = true;
            labelATM.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelATM.Location = new Point(29, 14);
            labelATM.Name = "labelATM";
            labelATM.Size = new Size(91, 30);
            labelATM.TabIndex = 9;
            labelATM.Text = "0.00000";
            // 
            // labelConcentracaoN2
            // 
            labelConcentracaoN2.Anchor = AnchorStyles.Bottom;
            labelConcentracaoN2.AutoSize = true;
            labelConcentracaoN2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelConcentracaoN2.Location = new Point(30, 14);
            labelConcentracaoN2.Name = "labelConcentracaoN2";
            labelConcentracaoN2.Size = new Size(91, 30);
            labelConcentracaoN2.TabIndex = 10;
            labelConcentracaoN2.Text = "0.00000";
            // 
            // labelMassaDeNitrogenio
            // 
            labelMassaDeNitrogenio.Anchor = AnchorStyles.Bottom;
            labelMassaDeNitrogenio.AutoSize = true;
            labelMassaDeNitrogenio.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelMassaDeNitrogenio.Location = new Point(26, 15);
            labelMassaDeNitrogenio.Name = "labelMassaDeNitrogenio";
            labelMassaDeNitrogenio.Size = new Size(91, 30);
            labelMassaDeNitrogenio.TabIndex = 11;
            labelMassaDeNitrogenio.Text = "0.00000";
            // 
            // labelPorcentagemN2
            // 
            labelPorcentagemN2.Anchor = AnchorStyles.Bottom;
            labelPorcentagemN2.AutoSize = true;
            labelPorcentagemN2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelPorcentagemN2.Location = new Point(12, 15);
            labelPorcentagemN2.Name = "labelPorcentagemN2";
            labelPorcentagemN2.Size = new Size(119, 32);
            labelPorcentagemN2.TabIndex = 12;
            labelPorcentagemN2.Text = "000.00 %";
            // 
            // buttonStart
            // 
            buttonStart.AutoSize = true;
            buttonStart.Location = new Point(12, 221);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 25);
            buttonStart.TabIndex = 9;
            buttonStart.Text = "Iniciar";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(109, 221);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 25);
            buttonStop.TabIndex = 10;
            buttonStop.Text = "Parar";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Teal;
            label1.Location = new Point(3, 37);
            label1.Name = "label1";
            label1.Size = new Size(135, 43);
            label1.TabIndex = 12;
            label1.Text = "Concentração de N2";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(labelConcentracaoN2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(150, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(141, 80);
            panel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 192, 192);
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
            panel2.Size = new Size(200, 472);
            panel2.TabIndex = 14;
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
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 74);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.Controls.Add(labelPorcentagemN2);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(444, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(141, 80);
            panel7.TabIndex = 19;
            panel7.Paint += panel7_Paint;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Teal;
            label7.Location = new Point(26, 47);
            label7.Name = "label7";
            label7.Size = new Size(85, 21);
            label7.TabIndex = 13;
            label7.Text = "% de TDG";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label6);
            panel6.Controls.Add(labelMassaDeNitrogenio);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(297, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(141, 80);
            panel6.TabIndex = 18;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom;
            label6.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Teal;
            label6.Location = new Point(5, 40);
            label6.Name = "label6";
            label6.Size = new Size(133, 37);
            label6.TabIndex = 13;
            label6.Text = "Massa de Nitrogênio";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            label6.Click += label6_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label5);
            panel5.Controls.Add(labelATM);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(141, 80);
            panel5.TabIndex = 17;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Teal;
            label5.Location = new Point(46, 48);
            label5.Name = "label5";
            label5.Size = new Size(48, 21);
            label5.TabIndex = 13;
            label5.Text = "ATM";
            // 
            // panel4
            // 
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(labelReadingStatus);
            panel4.Controls.Add(labelConnectionStatus);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(200, 437);
            panel4.Name = "panel4";
            panel4.Size = new Size(738, 35);
            panel4.TabIndex = 16;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 11);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 2;
            label3.Text = "Status da Conexão";
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
            // labelConnectionStatus
            // 
            labelConnectionStatus.AutoSize = true;
            labelConnectionStatus.Location = new Point(126, 11);
            labelConnectionStatus.Name = "labelConnectionStatus";
            labelConnectionStatus.Size = new Size(82, 15);
            labelConnectionStatus.TabIndex = 0;
            labelConnectionStatus.Text = "Desconectado";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Gray;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel3, 4, 0);
            tableLayoutPanel1.Controls.Add(panel5, 0, 0);
            tableLayoutPanel1.Controls.Add(panel7, 3, 0);
            tableLayoutPanel1.Controls.Add(panel6, 2, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(200, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(738, 86);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(labelTemperature);
            panel3.Controls.Add(label9);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(591, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(144, 80);
            panel3.TabIndex = 20;
            // 
            // labelTemperature
            // 
            labelTemperature.Anchor = AnchorStyles.Bottom;
            labelTemperature.AutoSize = true;
            labelTemperature.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelTemperature.Location = new Point(21, 18);
            labelTemperature.Name = "labelTemperature";
            labelTemperature.Size = new Size(108, 32);
            labelTemperature.TabIndex = 12;
            labelTemperature.Text = "00.00 C°";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Bottom;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.Teal;
            label9.Location = new Point(17, 47);
            label9.Name = "label9";
            label9.Size = new Size(112, 21);
            label9.TabIndex = 13;
            label9.Text = "Temperatura";
            label9.Click += label9_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 569);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(txtTerminal);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private Label labelATM;
        private Label labelConcentracaoN2;
        private Label labelMassaDeNitrogenio;
        private Label labelPorcentagemN2;
        private Button buttonStart;
        private Button buttonStop;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Label label4;
        private Label label3;
        private Label labelReadingStatus;
        private Label labelConnectionStatus;
        private Panel panel5;
        private Label label5;
        private Panel panel7;
        private Label label7;
        private Panel panel6;
        private Label label6;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Label labelTemperature;
        private Label label9;
    }
}