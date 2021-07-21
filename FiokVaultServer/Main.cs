using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//// Set the TcpListener on port 127.0.0.1:13000.
namespace FiokVaultServer
{
    public partial class Main : Form
    {
        private TCPConnection connection;
        private Thread listeningThread;
        private String IPAddress;
        public Main()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (CheckIP(mtbAddress.Text))
            {

                connection = new TCPConnection(IPAddress,txtServerOutput);

                connection.StartServer();


                listeningThread = new Thread(new ThreadStart(connection.StartListening));
                listeningThread.IsBackground = true;
                listeningThread.Start();

                btnStartServer.Enabled = false;
                btnStopServer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Invalid IP address!");
            }
        }

        private bool CheckIP(String address)
        {
            //Remove blank spaces from the IP
            address = Regex.Replace(address, @"\s+", "");

            //Check if IP is proper
            Match match = Regex.Match(address, "^\\d{0,3}.\\d{0,3}.\\d{0,3}.\\d{0,3}:\\d{0,5}$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                IPAddress = address;
                return true;
            }
            return false;
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (connection != null)
            {
                connection.StopServer();
                listeningThread.Interrupt();
                btnStartServer.Enabled = true;
                btnStopServer.Enabled = false;
            }
        }
    }
}
