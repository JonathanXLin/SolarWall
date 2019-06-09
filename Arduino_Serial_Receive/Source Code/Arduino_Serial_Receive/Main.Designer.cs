namespace Arduino_Serial_Receive
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.groupBoxDataReceived = new System.Windows.Forms.GroupBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.serialPortArduino = new System.IO.Ports.SerialPort(this.components);
            this.timerMillisecond = new System.Windows.Forms.Timer(this.components);
            this.groupBoxFileOutput = new System.Windows.Forms.GroupBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.buttonSelectCreateFile = new System.Windows.Forms.Button();
            this.labelCurrentDirectory = new System.Windows.Forms.Label();
            this.groupBoxSerial.SuspendLayout();
            this.groupBoxDataReceived.SuspendLayout();
            this.groupBoxFileOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(78, 20);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPort.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(231, 20);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(240, 51);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.labelPort);
            this.groupBoxSerial.Controls.Add(this.labelBaudRate);
            this.groupBoxSerial.Controls.Add(this.buttonConnect);
            this.groupBoxSerial.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxSerial.Controls.Add(this.comboBoxPort);
            this.groupBoxSerial.Location = new System.Drawing.Point(12, 134);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(497, 82);
            this.groupBoxSerial.TabIndex = 2;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial Connection";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(46, 23);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 4;
            this.labelPort.Text = "Port";
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(14, 53);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(58, 13);
            this.labelBaudRate.TabIndex = 3;
            this.labelBaudRate.Text = "Baud Rate";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(78, 50);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudRate.TabIndex = 2;
            this.comboBoxBaudRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudRate_SelectedIndexChanged);
            // 
            // groupBoxDataReceived
            // 
            this.groupBoxDataReceived.Controls.Add(this.textBoxTime);
            this.groupBoxDataReceived.Controls.Add(this.textBoxData);
            this.groupBoxDataReceived.Controls.Add(this.labelTime);
            this.groupBoxDataReceived.Controls.Add(this.labelData);
            this.groupBoxDataReceived.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDataReceived.Name = "groupBoxDataReceived";
            this.groupBoxDataReceived.Size = new System.Drawing.Size(269, 116);
            this.groupBoxDataReceived.TabIndex = 3;
            this.groupBoxDataReceived.TabStop = false;
            this.groupBoxDataReceived.Text = "Data Received";
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(54, 72);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(145, 20);
            this.textBoxTime.TabIndex = 5;
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(54, 32);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.Size = new System.Drawing.Size(145, 20);
            this.textBoxData.TabIndex = 4;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(18, 75);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(30, 13);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Time";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(18, 35);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(30, 13);
            this.labelData.TabIndex = 1;
            this.labelData.Text = "Data";
            // 
            // serialPortArduino
            // 
            this.serialPortArduino.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortArduino_DataReceived);
            // 
            // timerMillisecond
            // 
            this.timerMillisecond.Enabled = true;
            this.timerMillisecond.Interval = 1;
            this.timerMillisecond.Tick += new System.EventHandler(this.timerMillisecond_Tick);
            // 
            // groupBoxFileOutput
            // 
            this.groupBoxFileOutput.Controls.Add(this.labelDirectory);
            this.groupBoxFileOutput.Controls.Add(this.buttonSelectCreateFile);
            this.groupBoxFileOutput.Controls.Add(this.labelCurrentDirectory);
            this.groupBoxFileOutput.Location = new System.Drawing.Point(298, 12);
            this.groupBoxFileOutput.Name = "groupBoxFileOutput";
            this.groupBoxFileOutput.Size = new System.Drawing.Size(211, 116);
            this.groupBoxFileOutput.TabIndex = 4;
            this.groupBoxFileOutput.TabStop = false;
            this.groupBoxFileOutput.Text = "File Output";
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDirectory.Location = new System.Drawing.Point(20, 44);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(75, 13);
            this.labelDirectory.TabIndex = 3;
            this.labelDirectory.Text = "[Not Selected]";
            // 
            // buttonSelectCreateFile
            // 
            this.buttonSelectCreateFile.Location = new System.Drawing.Point(23, 72);
            this.buttonSelectCreateFile.Name = "buttonSelectCreateFile";
            this.buttonSelectCreateFile.Size = new System.Drawing.Size(162, 26);
            this.buttonSelectCreateFile.TabIndex = 2;
            this.buttonSelectCreateFile.Text = "Create Output File";
            this.buttonSelectCreateFile.UseVisualStyleBackColor = true;
            this.buttonSelectCreateFile.Click += new System.EventHandler(this.buttonSelectCreateFile_Click);
            // 
            // labelCurrentDirectory
            // 
            this.labelCurrentDirectory.AutoSize = true;
            this.labelCurrentDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentDirectory.Location = new System.Drawing.Point(20, 29);
            this.labelCurrentDirectory.Name = "labelCurrentDirectory";
            this.labelCurrentDirectory.Size = new System.Drawing.Size(86, 13);
            this.labelCurrentDirectory.TabIndex = 1;
            this.labelCurrentDirectory.Text = "Current Directory";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 227);
            this.Controls.Add(this.groupBoxFileOutput);
            this.Controls.Add(this.groupBoxDataReceived);
            this.Controls.Add(this.groupBoxSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arduino Serial Datalogger";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxSerial.PerformLayout();
            this.groupBoxDataReceived.ResumeLayout(false);
            this.groupBoxDataReceived.PerformLayout();
            this.groupBoxFileOutput.ResumeLayout(false);
            this.groupBoxFileOutput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.GroupBox groupBoxDataReceived;
        private System.IO.Ports.SerialPort serialPortArduino;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Timer timerMillisecond;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.GroupBox groupBoxFileOutput;
        private System.Windows.Forms.Button buttonSelectCreateFile;
        private System.Windows.Forms.Label labelCurrentDirectory;
        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Label labelDirectory;
    }
}

