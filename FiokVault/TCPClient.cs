using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Windows.Forms;

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

                byte[] encryptedMessage = FiokVaultClientEncrypt.encryptMessage(message);

                NetworkStream stream = client.GetStream();

                stream.Write(encryptedMessage, 0, encryptedMessage.Length);

                byte[] data = new byte[4096];

                String rawResponseData = String.Empty;
                Int32 bytes = stream.Read(data, 0, data.Length);
                var dataResponse = Encoding.ASCII.GetString(data, 0, bytes);
                string responseData = FiokVaultClientDecrypt.decryptMessage(Encoding.ASCII.GetBytes(dataResponse), FiokVaultClientEncrypt.byteKey);

                client.GetStream().Close();
                client.Close();
                return responseData;
            }
            catch (ArgumentNullException e)
            {
                throw new Exception("Ka ndodhur nje gabim \nMesazhi i plote: " + e.Message);
            }
            catch (SocketException e)
            {
                throw new Exception("Ka ndodhur nje gabim gjate lidhjes me server \nMesazhi i plote: " + e.Message);
            }
        }

        public static byte[] generateSafeRandom(int length)
        {
            byte[] safeRandom = new byte[length];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetBytes(safeRandom);
            return safeRandom;
        }
    }
}

