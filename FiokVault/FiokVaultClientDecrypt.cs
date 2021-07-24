using FiokVaultServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVault
{
    static class FiokVaultClientDecrypt
    {
        static int IVLength = 8;

        public static string decryptMessage(byte[] inputData, byte[] Key)
        {
            string encryptedData = Encoding.ASCII.GetString(inputData);
            string[] inputMessage = encryptedData.Split("$");

            byte[] IVp = new byte[IVLength];

                string message;
                FiokVaultDES des = new FiokVaultDES(Key);

                try
                {
                    message = des.Decrypt(inputMessage[1]);

                    return message;
                }
                catch (Exception e)
                {
                    return null;
                }
        }

    }
}
