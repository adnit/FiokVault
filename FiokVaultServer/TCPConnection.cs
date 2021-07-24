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
        public TCPConnection(String localAddress, TextBox output, ListBox clientList)
        {
            address = IPAddress.Parse(localAddress.Split(':')[0]);
            port = Int32.Parse(localAddress.Split(':')[1]);
            txtOutput = output;
            lbClient = clientList;
            FiokVaultServerDecrypt fvsd = new FiokVaultServerDecrypt();
            //MessageBox.Show(fvsd.decryptMessage(System.Text.Encoding.ASCII.GetBytes("???qe?$?6Q&??x?Kx	??tL??uL?um?~??{??9??Z~^?Aru?1Z??6?\\>???+???????(????>?%?:?????HdKEp??Z?%?>??V?[????zRY+?d?Yq????l??????QB???+v??????W*?m???2m????-?:us?4Dw???YW1v	?\" ? u ? tI ? ZQ ?? rH ? _ ? Aa ?\\??? ~??<??? k ? m ??? 2 ??}?Z[`??v ???? +1 ?? J_ ? _ ?? zv /??   $S ? 4 ?m ? c ? n ????? D = -;????? ?F?=9?????8?i???xs??HGRc??x? G	?V0?[oW[")));
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
                Byte[] bytes = new Byte[2048];
                // Get a stream object for reading and writing
                NetworkStream stream = client.GetStream();

                int i;

                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    //Qita e merr prej klientit
                    data = Convert.ToBase64String(bytes);
                    Debug.WriteLine(data);
                    FiokVaultServerDecrypt fvsd = new FiokVaultServerDecrypt();
                    data = System.Text.Encoding.UTF8.GetString(fvsd.decryptMessage(System.Text.Encoding.ASCII.GetBytes(data)));
                    byte[] sentKey = fvsd.decryptedKey;

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

                    //Pergjigja, ma saktesisht returnMessage; qita e dergon te klienti
                    byte[] response = System.Text.Encoding.ASCII.GetBytes(returnMessage);
                    FiokVaultServerEncrypt fvse = new FiokVaultServerEncrypt(sentKey);
                    response = fvse.encryptMessage(response);
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
