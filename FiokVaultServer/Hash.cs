using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class Hash
    {
        public const int SALT_SIZE = 16;
        public const int HASH_SIZE = 16;
        public const int ITERATIONS = 100000;
        public static byte[] CreateHash(string input)
        {
            RNGCryptoServiceProvider provider = new();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new(input, salt, ITERATIONS);
            return pbkdf2.GetBytes(HASH_SIZE);
        }

        public static string ByteToString(byte[] input)
        {
            string output = "";
            foreach(byte b in input)
            {
                output = b.ToString();
            }
            return output;
        }
    }
}
