using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace FiokVaultServer
{
    class TCPConnection
    {
        IPAddress address;
        Int32 port;
        TextBox txtOutput;
        ListBox lbClient;
        TcpListener server;
        Thread listeningThread;
        List<TcpClient> clients = new List<TcpClient>();
        public TCPConnection(String localAddress,TextBox output, ListBox clientList)
        {
            address = IPAddress.Parse(localAddress.Split(':')[0]);
            port = Int32.Parse(localAddress.Split(':')[1]);
            txtOutput = output;
            lbClient = clientList;
        } 
        public void StartServer()
        {
            PrintLine("Starting server!");
            server = new TcpListener(address, port);
            server.Start();
        }
        public void StartListening()
        {
            PrintLine("Listening for connections...");
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(ClientConnection, client);
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        public void StopServer()
        {
            PrintLine("Stopping the server!");
            clients.Clear();
            lbClient.Items.Clear();
            server.Stop();
        } 
        private void ClientConnection(object obj)
        {
            TcpClient client = (TcpClient)obj;
            PrintLine("Client connected with IP " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            AddClient(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            clients.Add(client);
        }
        public void RemoveClient(int index)
        {
            try {
                clients.RemoveAt(index); 
                }
            catch(Exception e)
            {
                Console.WriteLine("Error occurred while removing clients!");
            }
        }
        public void AddClient(String clientIP)
        {
            MethodInvoker action = delegate
            { lbClient.Items.Add(clientIP); };
            lbClient.BeginInvoke(action);
        }
        public void PrintLine(String text)
        {
            MethodInvoker action = delegate
             { txtOutput.Text += text + "\r\n"; };
            txtOutput.BeginInvoke(action);
        }
    }
}
