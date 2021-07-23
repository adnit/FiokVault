using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class FiokVaultServerDecrypt
    {
        static int IVLength = 8;
        static int RSAKeyLength = 256;
        static string PrivateKeyString = File.ReadAllText("..\\..\\..\\certificate\\privkey.pem");
        public byte[] decryptedKey;
        public byte[] decryptMessage(byte[] encryptedData)
        {

            string decodedmsg = Encoding.ASCII.GetString(Convert.FromBase64String(Convert.ToBase64String(encryptedData)));
            Debug.WriteLine(decodedmsg);
            String[] messages = decodedmsg.Split("$");

            foreach (var e in messages)
            {
                Debug.WriteLine(e);
            }


            byte[] IVp = new byte[IVLength];
            byte[] encryptedKey = new byte[RSAKeyLength];
            byte[] encryptedMessage = new byte[encryptedData.Length - IVLength - RSAKeyLength];
            Debug.WriteLine("/n/n" + decodedmsg + "/n/n");



            SplitArray(IVp, encryptedMessage, IVLength, encryptedData);
            SplitArray(encryptedKey, encryptedMessage, RSAKeyLength, encryptedMessage);

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                byte[] message;

                RSA.ImportFromPem(PrivateKeyString);
                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                byte[] decryptedKey = RSADecrypt(encryptedKey, RSA.ExportParameters(true), false);
                this.decryptedKey = decryptedKey;

                FiokVaultDES des = new FiokVaultDES(decryptedKey);

                message = Encoding.ASCII.GetBytes(des.Decrypt(Encoding.ASCII.GetString(encryptedMessage)));
                //Display the decrypted plaintext to the console. 
                //Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
                Console.WriteLine(message);
                return message;
            }
        }


        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }
        }

        static void SplitArray(byte[] firstHalf, byte[] secondHalf, int offset, byte[] sourceArray)
        {
            Array.Copy(sourceArray, firstHalf, offset);
            Array.Copy(sourceArray, offset, secondHalf, 0, secondHalf.Length);
        }
    }
}
