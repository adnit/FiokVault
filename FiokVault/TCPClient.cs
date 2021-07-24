using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Diagnostics;

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

                //message -> INPUT; qikjo i shkon serverit

                byte[] Key = generateSafeRandom(8);

                byte[] encryptedMessage = FiokVaultClientEncrypt.encryptMessage(message);

                Debug.WriteLine(Convert.ToBase64String(encryptedMessage));
                Debug.WriteLine(Convert.ToBase64String(encryptedMessage));

                NetworkStream stream = client.GetStream();



                //SEND DATA TO TCP SERVER; e qon datan
                stream.Write(encryptedMessage, 0, encryptedMessage.Length);

                byte[] data = new byte[2048];

                String responseData = String.Empty;


                //GET RESPONSE
                Int32 bytes = stream.Read(data, 0, data.Length);

                //responseData -> OUTPUT; qita e merr prej serverit
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                //FiokVaultClientDecrypt fvcd = new FiokVaultClientDecrypt(Key);
                //byte[] decryptedResponse = fvcd.decryptMessage(Encoding.ASCII.GetBytes(responseData));

                client.GetStream().Close();
                client.Close();
                return "OK";
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

