using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace Arduino_Serial_Receive
{
    public partial class Main : Form
    {
        //Serial connection variables
        bool isConnectedSerial = false;
        String[] ports;
        SerialPort port;

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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxPort.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
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

            MessageBox.Show(serialPortArduino.PortName.ToString());
        }
    }
}
