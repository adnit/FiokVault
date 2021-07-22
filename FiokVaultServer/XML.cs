using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace FiokVaultServer
{
    class XML
    {
        //   public List<User> users = new List<User>();

        public const int SALT_SIZE = 8;
        public const int HASH_SIZE = 8;
        public const int ITERATIONS = 100000;
        public XML(String url)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(url, XmlReadMode.InferSchema);
            Debug.WriteLine("\n" + dataSet.Tables.Count.ToString() + "\n");
            DataTable table = dataSet.Tables["User"];

            // e kqyr a ka user me kit username
            IEnumerable<XElement> currentUsers =
                from el in Users
                where (string)el.Attribute("username") == username
                select el;

            
            if (currentUsers.Count() == 0)
            {
                User user = new User();
                user.firstName = row["name"].ToString();
                user.lastName = row["surname"].ToString();
                user.username = row["username"].ToString();
                user.gjinia = row["gjinia"].ToString()[0];
                user.password = row["hashedpw"].ToString();
                users.Add(user);
            }
            else
            {

                // salti
                RNGCryptoServiceProvider provider = new();
                byte[] salt = new byte[SALT_SIZE];
                provider.GetBytes(salt);
                string saltStr = Convert.ToBase64String(salt);

                // hashedpw
                Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
                string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

            }

            // userid
            string userID = Users.Count() + 1.ToString();

            // salti
            RNGCryptoServiceProvider provider = new();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);
            string saltStr = Convert.ToBase64String(salt);

            // hashedpw
            Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
            string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

        }


        private void VerifyLogin() 
        { 
        
        }
    }
}
