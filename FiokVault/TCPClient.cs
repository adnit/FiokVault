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
        static string hostname = "127.000.000.001";
        static Int32 port = 13000;

        public static string sendMessage(string message)
        {
            try
            {
                TcpClient client = new TcpClient(hostname, port);

                Byte[] data = Encoding.ASCII.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                data = new Byte[1048];

                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);

                return responseData;
                client.GetStream().Close();
                client.Close();
                client = null;
            }
            catch (ArgumentNullException e)
            {
                throw new Exception("Ka ndodhur nje gabim \nMesazhi i plote: " + e.Message);
            }
            catch (SocketException e)
            {
                throw new Exception("Ka ndodhur nje gabim gjate lidhjes me server \nMesazhi i plote: " + e.Message);
            }
            return "ERROR";
        }
    }
}

