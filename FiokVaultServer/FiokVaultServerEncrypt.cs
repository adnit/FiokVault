using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class FiokVaultServerEncrypt
    {
        public byte[] Key;
        public int IVLength = 8;
        public FiokVaultServerEncrypt(byte[] Key)
        {
            this.Key = Key;
        }

        public byte[] encryptMessage(byte[] dataToEncrypt)
        {
            byte[] IV = new byte[IVLength];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetBytes(IV);

            FiokVaultDES des = new FiokVaultDES(this.Key);

            string encryptedMessage = des.Encrypt(Encoding.UTF8.GetString(dataToEncrypt));
            byte[] encryptedMessageArray = Encoding.UTF8.GetBytes(encryptedMessage);

            byte[] toBase64 = new byte[IVLength + encryptedMessage.Length];

            appendArray(IV, toBase64, 0);
            appendArray(encryptedMessageArray, toBase64, IVLength + encryptedMessageArray.Length);

            byte[] cipherText = Encoding.UTF8.GetBytes(Convert.ToBase64String(toBase64));

            return cipherText;
        }

        void appendArray(byte[] sourceArray, byte[] destinationArray, int offset)
        {
            Array.Copy(sourceArray, 0, destinationArray, offset, sourceArray.Length);
        }
    }
}
