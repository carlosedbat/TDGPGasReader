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
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            SuspendLayout();
            // 
            // txtTerminal
            // 
            txtTerminal.Location = new Point(330, 57);
            txtTerminal.Multiline = true;
            txtTerminal.Name = "txtTerminal";
            txtTerminal.ScrollBars = ScrollBars.Vertical;
            txtTerminal.Size = new Size(604, 436);
            txtTerminal.TabIndex = 0;
            // 
            // txtCommand
            // 
            txtCommand.Location = new Point(101, 470);
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
            btnSend.Location = new Point(12, 468);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(83, 25);
            btnSend.TabIndex = 4;
            btnSend.Text = "Enviar";
            btnSend.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 569);
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
    }
}