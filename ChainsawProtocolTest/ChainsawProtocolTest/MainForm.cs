using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ChainsawProtocolTest
{
    public partial class MainForm : Form
    {
        SerialPort sPort;

        public MainForm()
        {
            InitializeComponent();      // required
            Console.WriteLine("Chainsaw Protocol Test");
            initUI();
        }

        /// <summary>
        /// Load valid values for the user interface
        /// </summary>
        private void initUI()
        {
            // Nifty bit to use later
            // IEnumerable<string> ports = SerialPort.GetPortNames().ToList();
            // ports = ports.Select(e => e.Replace("COM", "Communications Port "));

            cboPort.DataSource = SerialPort.GetPortNames();
            cboPort.SelectedIndex = cboPort.Items.Count - 1;

            cboBaudRate.DataSource = new int[] { 4800, 9600, 19200, 38400, 57600, 115200, 130400 };
            cboBaudRate.SelectedIndex = 1;   // default to 9600 baud

            // Read with: (Parity)Enum.Parse(typeof(Parity), parity, true)
            cboParity.DataSource = new string[]
            { 
                Parity.None.ToString(),
                Parity.Even.ToString(),
                Parity.Odd.ToString(), 
                Parity.Space.ToString(),
                Parity.Mark.ToString()
            };

            cboDataBits.DataSource = new int[] { 5, 6, 7, 8, 9 };
            cboDataBits.SelectedIndex = 3;   // default to 8 data bits

            cboStopBits.DataSource = new string[] {
                StopBits.None.ToString(),
                StopBits.One.ToString(),
                StopBits.OnePointFive.ToString(),
                StopBits.Two.ToString()
            };

            cboHandshake.DataSource = new string[] {
                Handshake.None.ToString(),
                Handshake.RequestToSend.ToString(),
                Handshake.RequestToSendXOnXOff.ToString(),
                Handshake.XOnXOff.ToString()
            };
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Form loaded
        }
    }
}
