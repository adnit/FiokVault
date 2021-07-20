using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FiokVault
{
    class TCPClient
    {
        static TcpClient client;
        static NetworkStream stream;
        public TCPClient()
        {
            string hostname = "localhost";
            Int32 port = 13000;
            client = new TcpClient(hostname, port);
            NetworkStream stream = client.GetStream();
        }
        public static void sendMessage(string message)
        {
            //
            // TODO
            // Qetu dikun menohet me enkriptu
            //

            Byte[] data = Encoding.ASCII.GetBytes(message);
            // Byte[] data = Convert.FromBase64String(message); // nese i qet giberish
            stream.Write(data, 0, data.Length);
        }

        public static string receiveMessage()
        {
            Byte[] data = new Byte[256];
            String responseData = String.Empty;

            //
            // TODO
            // Qetu dikun menohet me dekriptu
            //

            Int32 bytes = stream.Read(data, 0, data.Length);
            // responseData = Convert.ToBase64String(data, 0, bytes); // nese i qet giberish
            responseData = Encoding.ASCII.GetString(data, 0, bytes);
            return responseData;
        }
        public static void closeConnection()
        {
            stream.Close();
            client.Close();
        }
    }
}
