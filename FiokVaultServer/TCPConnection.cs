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
            try
            {
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

                    string returnMessage = "";
                    User user = new User();
                    switch (Server.ReadRequestType(data))
                    {
                        case "INSERT":
                            returnMessage = XML.InsertData(data);
                            break;
                        case "LOGIN":
                            user = Server.ReadLoginInfo(data);
                            returnMessage = XML.LoginUser(user);
                            break;
                        case "SIGNUP":
                            user = Server.ReadSignupInfo(data);
                            returnMessage = XML.RegisterUser(user);
                            break;
                        case "GETDATA":
                            string username = Server.GetData(data);
                            returnMessage = XML.GetData(username);
                            break;
                        default:
                            returnMessage = "ERROR";
                            break;
                    }

                    byte[] response = System.Text.Encoding.ASCII.GetBytes(returnMessage);

                    // Send back a response.
                    stream.Write(response, 0, response.Length);
                    PrintLine("Sent: " + returnMessage);
                }
                client.Close();
            }
            catch(Exception en)
            {
                PrintLine("Client forcefully disconnected!");
                PrintLine(en.Message);  
            }
            finally
            {
                RemoveClient(0);
                client.Close();
            }

        }
        public void RemoveClient(int index)
        {
            try {
                clients.RemoveAt(index);
                MethodInvoker action = delegate
                { lbClient.Items.RemoveAt(index); };
                lbClient.BeginInvoke(action);
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
