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

namespace sender
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort();
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            sp.PortName = "COM8";
            sp.ReadTimeout = 2000;
            sp.Open();
            sp.Write("AT\r");
            sp.Write("AT+CMGF=1\r");
            System.Threading.Thread.Sleep(1500);
            sp.Write(txt_message.Text + "\x1A");
            MessageBox.Show("Done","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            sp.Close();
        }
    }
}
