using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FiokVaultServer;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace FiokVault
{
    static class FiokVaultClientEncrypt
    {
        static string PublicKeyString = File.ReadAllText("..\\..\\..\\certificate\\publickey.txt");
        //private static byte[] Key = UTF8Encoding.ASCII.GetBytes(mysecurityKey);
        public static byte[] byteKey;
        public static int IVLength = 8;
        public static byte[] encryptMessage(string input)
        {

            byteKey = TCPClient.generateSafeRandom(64);

            string stringIV = Convert.ToBase64String(TCPClient.generateSafeRandom(8));

            byte[] byteRSA = FiokVaultClientEncrypt.RSAEncrypt(byteKey, FiokVaultClientEncrypt.getPublicParameters(File.ReadAllText("..\\..\\..\\certificate\\publickey.txt")), false);
            string stringRSA = Convert.ToBase64String(byteRSA);

            FiokVaultDES des = new FiokVaultDES(byteKey);
            byte[] byteDes = des.Encrypt(input);
            string stringDes = Convert.ToBase64String(byteDes);

            input = (stringIV) + "//+//" + (stringRSA) + "//+//" + (stringDes);

            byte[] output = Convert.FromBase64String(Convert.ToBase64String(Encoding.ASCII.GetBytes(input)));
            return output;
        }

        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }
        }

        static public RSAParameters getPublicParameters(string keyString)
        {
            // 3 5
            // 3 - 8
            keyString = keyString.Substring(26, keyString.Length - 24 - 26);
            //Asn1Object obj = Asn1Object.FromByteArray(Convert.FromBase64String(keyString));
            Asn1Object obj = Asn1Object.FromByteArray(Convert.FromBase64String(keyString));
            DerSequence publicKeySequence = (DerSequence)obj;

            DerBitString encodedPublicKey = (DerBitString)publicKeySequence[1];
            DerSequence publicKey = (DerSequence)Asn1Object.FromByteArray(encodedPublicKey.GetBytes());

            DerInteger modulus = (DerInteger)publicKey[0];
            DerInteger exponent = (DerInteger)publicKey[1];
            RsaKeyParameters keyParameters = new RsaKeyParameters(false, modulus.PositiveValue, exponent.PositiveValue);
            RSAParameters parameters = DotNetUtilities.ToRSAParameters(keyParameters);
            return parameters;
        }

        public static string DESDecrypt(string TextToDecrypt)
        {
            MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash(byteKey);
            MyMD5CryptoService.Clear();

            var MyTripleDESCryptoService = new TripleDESCryptoServiceProvider();

            //byte[] IV = new byte[8];
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            //provider.GetBytes(IV);

            byte[] MyDecryptArray = Convert.FromBase64String(TextToDecrypt);

            int IVLength = 8;
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

            return UTF8Encoding.ASCII.GetString(MyresultArray);
        }

        static void SplitArray(byte[] firstHalf, byte[] secondHalf, int offset, byte[] sourceArray)
        {
            Array.Copy(sourceArray, firstHalf, offset);
            Array.Copy(sourceArray, offset, secondHalf, 0, secondHalf.Length);
        }


        static void appendArray(byte[] sourceArray, byte[] destinationArray, int offset)
        {
            Array.Copy(sourceArray, 0, destinationArray, offset, sourceArray.Length);
        }
    }
}
