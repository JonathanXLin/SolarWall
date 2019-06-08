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
            this.comboBoxPort = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.groupBoxSerial = new System.Windows.Forms.GroupBox();
            this.groupBoxDataReceived = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimestamp = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelDataReceived = new System.Windows.Forms.Label();
            this.serialPortArduino = new System.IO.Ports.SerialPort(this.components);
            this.timerMillisecond = new System.Windows.Forms.Timer(this.components);
            this.groupBoxSerial.SuspendLayout();
            this.groupBoxDataReceived.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPort
            // 
            this.comboBoxPort.FormattingEnabled = true;
            this.comboBoxPort.Location = new System.Drawing.Point(14, 19);
            this.comboBoxPort.Name = "comboBoxPort";
            this.comboBoxPort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPort.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(14, 46);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(121, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // groupBoxSerial
            // 
            this.groupBoxSerial.Controls.Add(this.comboBoxPort);
            this.groupBoxSerial.Controls.Add(this.buttonConnect);
            this.groupBoxSerial.Location = new System.Drawing.Point(12, 101);
            this.groupBoxSerial.Name = "groupBoxSerial";
            this.groupBoxSerial.Size = new System.Drawing.Size(305, 82);
            this.groupBoxSerial.TabIndex = 2;
            this.groupBoxSerial.TabStop = false;
            this.groupBoxSerial.Text = "Serial Connection";
            // 
            // groupBoxDataReceived
            // 
            this.groupBoxDataReceived.Controls.Add(this.labelTime);
            this.groupBoxDataReceived.Controls.Add(this.labelTimestamp);
            this.groupBoxDataReceived.Controls.Add(this.labelData);
            this.groupBoxDataReceived.Controls.Add(this.labelDataReceived);
            this.groupBoxDataReceived.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDataReceived.Name = "groupBoxDataReceived";
            this.groupBoxDataReceived.Size = new System.Drawing.Size(305, 83);
            this.groupBoxDataReceived.TabIndex = 3;
            this.groupBoxDataReceived.TabStop = false;
            this.groupBoxDataReceived.Text = "Data Received";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTime.Location = new System.Drawing.Point(131, 27);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(95, 20);
            this.labelTime.TabIndex = 3;
            this.labelTime.Text = "Time (h:m:s)";
            // 
            // labelTimestamp
            // 
            this.labelTimestamp.AutoSize = true;
            this.labelTimestamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimestamp.Location = new System.Drawing.Point(131, 50);
            this.labelTimestamp.Name = "labelTimestamp";
            this.labelTimestamp.Size = new System.Drawing.Size(18, 20);
            this.labelTimestamp.TabIndex = 2;
            this.labelTimestamp.Text = "0";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelData.Location = new System.Drawing.Point(20, 27);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(44, 20);
            this.labelData.TabIndex = 1;
            this.labelData.Text = "Data";
            // 
            // labelDataReceived
            // 
            this.labelDataReceived.AutoSize = true;
            this.labelDataReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataReceived.Location = new System.Drawing.Point(20, 50);
            this.labelDataReceived.Name = "labelDataReceived";
            this.labelDataReceived.Size = new System.Drawing.Size(18, 20);
            this.labelDataReceived.TabIndex = 0;
            this.labelDataReceived.Text = "0";
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 195);
            this.Controls.Add(this.groupBoxDataReceived);
            this.Controls.Add(this.groupBoxSerial);
            this.Name = "Main";
            this.Text = "Arduino Serial Datalogger";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBoxSerial.ResumeLayout(false);
            this.groupBoxDataReceived.ResumeLayout(false);
            this.groupBoxDataReceived.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.GroupBox groupBoxSerial;
        private System.Windows.Forms.GroupBox groupBoxDataReceived;
        private System.Windows.Forms.Label labelDataReceived;
        private System.IO.Ports.SerialPort serialPortArduino;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTimestamp;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Timer timerMillisecond;
    }
}

