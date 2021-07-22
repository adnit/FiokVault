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
        static string hostname = "185.323.112.3";
        static Int32 port = 13000;

        public static string sendMessage(string message)
        {
            try
            { 
            TcpClient client = new TcpClient(hostname, port);
            NetworkStream stream = client.GetStream(); 
            //
            // TODO
            // Qetu dikun menohet me enkriptu
            //

            Byte[] data = Encoding.ASCII.GetBytes(message);
                // Byte[] data = Convert.FromBase64String(message); // nese i qet giberish
                stream.Write(data, 0, data.Length);
            }
            catch (ArgumentNullException e)
            {
                throw new Exception("Ka ndodhur nje gabim \nMesazhi i plote: " + e.Message);
            }
            catch (SocketException e)
            {
                throw new Exception("Ka ndodhur nje gabim gjate lidhjes me server \nMesazhi i plote: " + e.Message);
            }
            try
                {
                    TcpClient client = new TcpClient(hostname, port);
                    NetworkStream stream = client.GetStream();
                    Byte[] data = new Byte[256];
                    String responseData;

                    //
                    // TODO
                    // Qetu dikun menohet me dekriptu
                    //

                    Int32 bytes = stream.Read(data, 0, data.Length);
                    // responseData = Convert.ToBase64String(data, 0, bytes); // nese i qet giberish
                    responseData = Encoding.ASCII.GetString(data, 0, bytes);
                    stream.Close();
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
        }
    }

