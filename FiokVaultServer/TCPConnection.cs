using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public TCPConnection(String localAddress, TextBox output, ListBox clientList)
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
                Byte[] bytes = new Byte[4096];
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, i);
                    data = FiokVaultServerDecrypt.decryptMessage(Encoding.ASCII.GetBytes(data));
                    PrintLine("Received after decryption: " + data);

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

                    byte[] response = FiokVaultServerEncrypt.encryptMessage(returnMessage, FiokVaultServerDecrypt.savedDecryptedKey);
                    //ma saktesisht qitu e dergon
                    stream.Write(response, 0, response.Length);


                    if (returnMessage == "ERROR" || returnMessage == "OK")
                        PrintLine("Sent: " + returnMessage);
                    else
                        PrintLine("Sent: " + "XML INFO");

                    client.Close();

                }

            }
            catch (Exception en)
            {
                RemoveClient(0);
            }
        }
        public void RemoveClient(int index)
        {
            try
            {
                clients.RemoveAt(index);
                MethodInvoker action = delegate
                { lbClient.Items.RemoveAt(index); };
                lbClient.BeginInvoke(action);
            }
            catch (Exception e)
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
