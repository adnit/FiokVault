using System;
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
        TcpListener server;
        Thread listeningThread;
        public TCPConnection(String localAddress,TextBox output)
        {
            address = IPAddress.Parse(localAddress.Split(':')[0]);
            port = Int32.Parse(localAddress.Split(':')[1]);
            txtOutput = output;
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
            server.Stop();
        }
    
        private void ClientConnection(object obj)
        {
            TcpClient client = (TcpClient)obj;
            PrintLine(client + "Connected!");
        }

        public void PrintLine(String text)
        {
            MethodInvoker action = delegate
             { txtOutput.Text += text + "\r\n"; };
            txtOutput.BeginInvoke(action);
        }
    }
}
