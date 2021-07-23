using FiokVaultServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVault
{
    class FiokVaultClientDecrypt
    {
        public byte[] Key;
        int IVLength = 8;
        public FiokVaultClientDecrypt(byte[] Key)
        {
            this.Key = Key;
        }

        public byte[] decryptMessage(byte[] encryptedData)
        {
            byte[] IVp = new byte[IVLength];
            byte[] encryptedMessage = new byte[encryptedData.Length - IVLength];
            SplitArray(IVp, encryptedMessage, IVLength, encryptedData);

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                byte[] message;
                FiokVaultDES des = new FiokVaultDES(this.Key);

                try
                {
                    message = Encoding.ASCII.GetBytes(des.Decrypt(Encoding.ASCII.GetString(encryptedMessage)));
                    //Display the decrypted plaintext to the console. 
                    //Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));

                    return message;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        static void SplitArray(byte[] firstHalf, byte[] secondHalf, int offset, byte[] sourceArray)
        {
            Array.Copy(sourceArray, firstHalf, offset);
            Array.Copy(sourceArray, offset, secondHalf, 0, secondHalf.Length);
        }

    }
}
