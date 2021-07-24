using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    static class FiokVaultServerEncrypt
    {
        static public int IVLength = 8;
        public static byte[] encryptMessage(string data, byte[] Key)
        {
            string responseMessage = data;

            FiokVaultDES des = new FiokVaultDES(FiokVaultServerDecrypt.savedDecryptedKey);
            byte[] encryptedMessage = des.Encrypt(responseMessage);

            //IV diqka
            byte[] IV = new byte[IVLength];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetBytes(IV);
            byte[] toBase64 = new byte[IV.Length + encryptedMessage.Length];

            string IVstr = Convert.ToBase64String(IV);
            string encMsg = Convert.ToBase64String(encryptedMessage);
            string cipherTxt = IVstr + "$" + encMsg;

            byte[] output = Convert.FromBase64String(Convert.ToBase64String(Encoding.ASCII.GetBytes(cipherTxt)));
            return output;
        }
    }
}
