using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Diagnostics;

namespace Arduino_Serial_Receive
{
    public partial class Main : Form
    {
        //Serial connection variables
        bool isConnectedSerial = false;
        String[] ports;
        Stopwatch stopwatch = new Stopwatch();

        public Main()
        {
            InitializeComponent();

            //Search for serial connections
            ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxPort.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBoxPort.SelectedItem = ports[0];
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;

            textBoxData.Text = "Disconnected";

            timerMillisecond.Enabled = true;

            buttonConnect.Enabled = false;

            comboBoxBaudRate.Items.Add("300");
            comboBoxBaudRate.Items.Add("600");
            comboBoxBaudRate.Items.Add("1200");
            comboBoxBaudRate.Items.Add("2400");
            comboBoxBaudRate.Items.Add("4800");
            comboBoxBaudRate.Items.Add("9600");
            comboBoxBaudRate.Items.Add("14400");
            comboBoxBaudRate.Items.Add("19200");
            comboBoxBaudRate.Items.Add("28800");
            comboBoxBaudRate.Items.Add("38400");
            comboBoxBaudRate.Items.Add("57600");
            comboBoxBaudRate.Items.Add("115200");

            comboBoxBaudRate.SelectedText = "9600";
        }

        private void connectToArduino()
        {
            isConnectedSerial = true;
            string selectedPort = comboBoxPort.GetItemText(comboBoxPort.SelectedItem);
            serialPortArduino.PortName = selectedPort;
            serialPortArduino.BaudRate = 9600;
            serialPortArduino.Open();
            buttonConnect.Text = "Disconnect";

            stopwatch.Start();

            /*
            isConnectedSerial = true;
            string selectedPort = comboBoxPort.GetItemText(comboBoxPort.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            buttonConnect.Text = "Disconnect";
            */
        }

        private void disconnectFromArduino()
        {
            isConnectedSerial = false;
            serialPortArduino.Close();

            buttonConnect.Text = "Connect";
            textBoxData.Text = "Disconnected";

            stopwatch.Stop();
            stopwatch.Reset();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (comboBoxPort.Items.Count == 0) {}
            else if (!isConnectedSerial)
                connectToArduino();
            else
                disconnectFromArduino();
        }

        private void serialPortArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isConnectedSerial)
            {
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadLine();

                Globals.dataReceived = indata;
                new_data(indata);
            }
        }

        public void new_data(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(new_data), new object[] { value });
                return;
            }

            textBoxData.Text = value;

            StreamWriter stream = File.AppendText(Globals.saveFileDialog.FileName);

            var str = stopwatch.Elapsed.ToString("c");
            stream.Write(str.Substring(0, str.Length - 4) + "\t\t\t" + value.ToString());

            stream.Close();
            stream.Dispose();

            /*
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Created On: " + DateTime.UtcNow.ToString() + "UTC");
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                var str = stopwatch.Elapsed.ToString("c");
                sw.Write(str.Substring(0, str.Length - 4) + "\t\t\t" + value.ToString());
            }
            */
        }

        private void timerMillisecond_Tick(object sender, EventArgs e)
        {
            var str = stopwatch.Elapsed.ToString("c");
            textBoxTime.Text = str.Substring(0, str.Length - 4);
        }

        private void buttonSelectCreateFile_Click(object sender, EventArgs e)
        {
            Globals.saveFileDialog.InitialDirectory = "";
            Globals.saveFileDialog.Title = "Save text Files";
            Globals.saveFileDialog.CheckFileExists = false;
            Globals.saveFileDialog.CheckPathExists = true;
            Globals.saveFileDialog.DefaultExt = "txt";
            Globals.saveFileDialog.FileName = "Arduino_Data.txt";
            Globals.saveFileDialog.Filter = "Text File | *.txt";
            Globals.saveFileDialog.FilterIndex = 2;
            Globals.saveFileDialog.RestoreDirectory = true;
            Globals.saveFileDialog.CreatePrompt = false;
            Globals.saveFileDialog.OverwritePrompt = true;

            if (Globals.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (File.Create(Globals.saveFileDialog.FileName)) { }

                StreamWriter stream = new StreamWriter(Globals.saveFileDialog.FileName);
                stream.WriteLine("Created On: " + DateTime.UtcNow.ToString() + " UTC");
                stream.Close();
                stream.Dispose();

                Globals.directorySelected = true;
                buttonConnect.Enabled = true;
            }
        }

        private void comboBoxBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {

            serialPortArduino.BaudRate = Convert.ToInt32(comboBoxBaudRate.SelectedItem.ToString());
        }
    }

    public static class Globals
    {
        public static SaveFileDialog saveFileDialog = new SaveFileDialog();

        public static string dataReceived = "";

        public static bool directorySelected = false;
        public static string fileDirectory = "";
    }
}
