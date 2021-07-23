using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class FiokVaultDecrypt
    {
        static string PrivateKeyString = File.ReadAllText("..\\..\\..\\certificate\\privkey.pem");

        public byte[] decryptMessage(byte[] encryptedData)
        {
            string decodedString = Encoding.UTF8.GetString(encryptedData);
            String[] messages = decodedString.Split(",");

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                byte[] message;
                String encryptedKey = messages[1];

                RSA.ImportFromPem(PrivateKeyString);
                //Pass the data to DECRYPT, the private key information 
                //(using RSACryptoServiceProvider.ExportParameters(true),
                //and a boolean flag specifying no OAEP padding.
                byte[] decryptedKey = RSADecrypt(UTF8Encoding.UTF8.GetBytes(encryptedKey), RSA.ExportParameters(true), false);

                FiokVaultDES des = new FiokVaultDES(decryptedKey);

                message = Encoding.ASCII.GetBytes(des.Decrypt(messages[2]));
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
