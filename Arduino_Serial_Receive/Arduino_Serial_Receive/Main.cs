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

            labelDataReceived.Text = "Disconnected";

            timerMillisecond.Enabled = true;
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
            labelDataReceived.Text = "Disconnect";

            stopwatch.Stop();
            stopwatch.Reset();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (comboBoxPort.Items.Count == 0)
            { }
            else if (!isConnectedSerial)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
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

            labelDataReceived.Text = value;

            string path = "Data_From_Arduino.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Created On: " + DateTime.UtcNow.ToString() + "UTC");
                }
            }

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write((stopwatch.ElapsedMilliseconds / (3600 * 1000)).ToString() + ":" + (stopwatch.ElapsedMilliseconds / (60 * 1000)).ToString() + ":" + (stopwatch.ElapsedMilliseconds / (1000)).ToString() + "\t\t" + value);
            }
        }

        private void timerMillisecond_Tick(object sender, EventArgs e)
        {
            labelTimestamp.Text = (stopwatch.ElapsedMilliseconds / (3600*1000)).ToString() + ":" + (stopwatch.ElapsedMilliseconds / (60 * 1000)).ToString() + ":" + (stopwatch.ElapsedMilliseconds / (1000)).ToString();
        }
    }

    public static class Globals
    {
        public static string dataReceived = "";
    }
}
