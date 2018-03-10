using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsTCP
{
    public partial class Form1 : Form
    {

        private const int Port = 51388;
        private TcpListener tcpLister = null;
        IPAddress ipaddress;

        
        public Form1()
        {
            InitializeComponent();
        }

        private void acceptClientConnect() {
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
