using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FiokVaultServer
{
    class TCPConnection
    {
        IPAddress address;
        Int32 port;
        TcpListener server;
        Thread listeningThread;
        public TCPConnection(String localAddress)
        {
            address = IPAddress.Parse(localAddress.Split(':')[0]);
            port = Int32.Parse(localAddress.Split(':')[1]);
        }
   
        public void StartServer()
        {
            server = new TcpListener(address, port);
            server.Start();
        }
        public void StartListening()
        {
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
            finally
            {
                StopServer();
            }
        }
        public void StopServer()
        {
            server.Stop();
        }
    
        private void ClientConnection(object obj)
        {
            TcpClient client = (TcpClient)obj;
            Console.WriteLine(client + " connected!");
        }
    }
}
