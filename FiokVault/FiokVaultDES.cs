using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class FiokVaultDES
    {
        public byte[] Key;
        public int IVLength = 8;

        public FiokVaultDES(byte[] Key)
        {
            this.Key = Key;
        }
        public string Encrypt(string TextToEncrypt)
        {
            byte[] MyEncryptedArray = Encoding.UTF8.GetBytes(TextToEncrypt);

            MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash(Key);
            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            byte[] IV = new byte[8];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetBytes(IV);

            MyTripleDESCryptoService.IV = IV;
            MyTripleDESCryptoService.Key = MysecurityKeyArray;
            MyTripleDESCryptoService.Mode = CipherMode.CBC;
            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService.CreateEncryptor();

            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(MyEncryptedArray, 0, MyEncryptedArray.Length);
            MyTripleDESCryptoService.Clear();

            byte[] encrypted = prepandToArray(IV, MyresultArray);
            Console.WriteLine(encrypted.Length);

            return Convert.ToBase64String(encrypted, 0, encrypted.Length);
        }

        static byte[] prepandToArray(byte[] prepand, byte[] array)
        {
            byte[] result = new byte[prepand.Length + array.Length];

            for (int i = 0; i < prepand.Length; i++)
            {
                result[i] = prepand[i];
            }
            Array.Copy(array, 0, result, prepand.Length, array.Length); // copy the old values

            return result;
        }

        public string Decrypt(string TextToDecrypt)
        {
            MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash(this.Key);
            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            byte[] MyDecryptArray = Convert.FromBase64String(TextToDecrypt);

            byte[] IV = new byte[IVLength];
            byte[] cipherText = new byte[MyDecryptArray.Length - IVLength];
            SplitArray(IV, cipherText, IVLength, MyDecryptArray);

            MyTripleDESCryptoService.IV = IV;
            MyTripleDESCryptoService.Key = MysecurityKeyArray;
            MyTripleDESCryptoService.Mode = CipherMode.CBC;
            MyTripleDESCryptoService.Padding = PaddingMode.PKCS7;

            var MyCrytpoTransform = MyTripleDESCryptoService.CreateDecryptor();

            byte[] MyresultArray = MyCrytpoTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);
            MyTripleDESCryptoService.Clear();

            return Encoding.UTF8.GetString(MyresultArray);
        }

        static void SplitArray(byte[] firstHalf, byte[] secondHalf, int offset, byte[] sourceArray)
        {
            Array.Copy(sourceArray, firstHalf, offset);
            Array.Copy(sourceArray, offset, secondHalf, 0, secondHalf.Length);
        }

    }
}
