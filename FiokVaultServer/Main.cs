using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        private String ipAddress;
        public Main()
        {
            InitializeComponent();

        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            if (CheckIP(mtbAddress.Text))
            {
                connection = new TCPConnection(ipAddress, txtServerOutput, lbClientIP);

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
            Match match = Regex.Match(address, "^\\d{1,3}.\\d{1,3}.\\d{1,3}.\\d{1,3}:\\d{1,5}$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ipAddress = address;
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

        private void btnClientDisconnect_Click(object sender, EventArgs e)
        {
            int index = lbClientIP.SelectedIndex;
            if (lbClientIP.Items.Count > 0 && index >= 0)
            {
                txtServerOutput.AppendText("Disconnected " + lbClientIP.Items[index] + "\r\n");
                lbClientIP.Items.RemoveAt(index);
                connection.RemoveClient(index);
               
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtServerOutput.Text = "";
        }

        private void txtServerOutput_TextChanged(object sender, EventArgs e)
        {
            txtServerOutput.SelectionStart = txtServerOutput.TextLength;
            //scroll to the caret
            txtServerOutput.ScrollToCaret();
        }
    }
}
