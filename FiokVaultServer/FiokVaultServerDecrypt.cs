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
    static class FiokVaultServerDecrypt
    {
        static int IVLength = 8;
        static int RSAKeyLength = 256;
        static string PrivateKeyString = File.ReadAllText("..\\..\\..\\certificate\\privkey.pem");
        public static byte[] savedDecryptedKey;
        public static byte[] savedIV;
        public static string decryptMessage(byte[] inputData)
        {
            string encryptedData = Encoding.ASCII.GetString(inputData);
            string[] inputMessage = encryptedData.Split("$");



            byte[] IVp = Convert.FromBase64String(inputMessage[0]);
            savedIV = IVp;
            byte[] encryptedKey = Convert.FromBase64String(inputMessage[1]);
            byte[] encryptedMessage = Convert.FromBase64String(inputMessage[2]);


            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
        

                RSA.ImportFromPem(PrivateKeyString);
                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                byte[] decryptedKey = RSADecrypt(encryptedKey, RSA.ExportParameters(true), false);
                savedDecryptedKey = decryptedKey;

                FiokVaultDES des = new FiokVaultDES(decryptedKey);

                
                string message = des.Decrypt(Convert.ToBase64String(encryptedMessage));
                //Display the decrypted plaintext to the console. 
                //Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
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
    }
}
