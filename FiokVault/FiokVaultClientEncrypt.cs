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
    class FiokVaultClientEncrypt
    {
        static string PublicKeyString = File.ReadAllText("..\\..\\..\\certificate\\publickey.txt");
        //private static byte[] Key = UTF8Encoding.ASCII.GetBytes(mysecurityKey);
        private byte[] Key;
        public int IVLength = 8;
        public FiokVaultClientEncrypt(byte[] Key)
        {
            this.Key = Key;
        }
        public byte[] encryptMessage(byte[] dataToEncrypt)
        {
            //Create a new instance of RSACryptoServiceProvider to generate
            //public and private key data.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                byte[] IV = new byte[IVLength];
                RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
                provider.GetBytes(IV);



                //Pass the data to ENCRYPT, the public key information 
                //(using RSACryptoServiceProvider.ExportParameters(false),
                //and a boolean flag specifying no OAEP padding.
                RSAParameters parameters = getPublicParameters(PublicKeyString);
                byte[] encryptedKey = RSAEncrypt(dataToEncrypt, parameters, false);




                FiokVaultDES des = new FiokVaultDES(this.Key);
                byte[] encryptedMessageArray = des.Encrypt(Encoding.ASCII.GetString(dataToEncrypt));

                byte[] toBase64 = new byte[IVLength + encryptedKey.Length + encryptedMessageArray.Length];


                string IVStr = Encoding.ASCII.GetString(IV);
                string encryptedKeyStr = Encoding.ASCII.GetString(encryptedKey);
                string encryptedMsgStr = Encoding.ASCII.GetString(encryptedMessageArray);

                string messageStr = IVStr + "$" + encryptedKeyStr + "$" + encryptedMsgStr;
                string encryptedResponse = Convert.ToBase64String(Encoding.ASCII.GetBytes(messageStr));

                byte[] message = Convert.FromBase64String(encryptedResponse);
                return message;
            }
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

        public string DESDecrypt(string TextToDecrypt)
        {
            MD5CryptoServiceProvider MyMD5CryptoService = new MD5CryptoServiceProvider();
            byte[] MysecurityKeyArray = MyMD5CryptoService.ComputeHash(this.Key);
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


        void appendArray(byte[] sourceArray, byte[] destinationArray, int offset)
        {
            Array.Copy(sourceArray, 0, destinationArray, offset, sourceArray.Length);
        }
    }
}
