using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
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

            string data = null;
            Byte[] bytes = new Byte[256];
            // Get a stream object for reading and writing
            NetworkStream stream = client.GetStream();

            int i;

            // Loop to receive all the data sent by the client.
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                // Translate data bytes to a ASCII string.
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                PrintLine("Received: " + data);

                // Process the data sent by the client.
                data = data.ToUpper();

                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                // Send back a response.
                stream.Write(msg, 0, msg.Length);
                PrintLine("Sent: " + data);
            }

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
