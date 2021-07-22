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
        public string salt;
        public string hashedpw;
        public string userSalt;
        public string userHashedPw;
        public Hash(string password)
        {
            this.hashedpw = Convert.ToBase64String(CreateHashedPassword(password));
        }
        public Hash(string userSalt, string userHashedPw)
        {
            this.userSalt = userSalt;
            this.userHashedPw = userHashedPw;
        }
        public byte[] CreateHashedPassword(string input)
        {
            RNGCryptoServiceProvider provider = new();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);
            this.salt = Convert.ToBase64String(salt);

            Rfc2898DeriveBytes pbkdf2 = new(input, salt, ITERATIONS);
            return pbkdf2.GetBytes(HASH_SIZE);
        }

        public bool CheckUser(string password)
        {
            byte[] salt = Convert.FromBase64String(this.userSalt);
            Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
            string hashedpw = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));
            return this.userHashedPw == hashedpw;
        }
    }
}
