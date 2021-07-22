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
        public
        const int SALT_SIZE = 8;
        public
        const int HASH_SIZE = 8;
        public
        const int ITERATIONS = 100000;
        public XML(String url)
        {
            LoginUser("adni111tadnit", "adnitadnit", url);
            // RegisterUser("test@test.com", "adni111tadnit", "M", "adnitadnit", url);
            // InsertData("adni111tadnit", "BLerjeee", "20022", "janar", "2.2", url);
            // GetData(url, "adni111tadnit");
        }

        public void RegisterUser(string email, string username, string gjinia, string password, string url)
        {
            XElement root = XElement.Load(url);
            IEnumerable<XElement> Users = root.Elements("User");

            // e kqyr a ka user me kit username
            IEnumerable<XElement> currentUsers =
              from el in Users
              where (string)el.Attribute("username") == username
              select el;

            // userid
            string userID = Users.Count() + 1.ToString();

            // salti

            Hash newUser = new(password);

            if (currentUsers.Count() == 0)
            {
                root.Add(new XElement("User",
                  new XAttribute("userid", userID),
                  new XAttribute("email", email),
                  new XAttribute("username", username),
                  new XAttribute("gjinia", gjinia),
                  new XAttribute("salt", newUser.salt),
                  new XAttribute("hashedpw", newUser.hashedpw)
                ));
                root.Save(url);
                newUser = null;
                Debug.WriteLine("OK");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }
        public void LoginUser(string username, string password, string url)
        {
            XElement root = XElement.Load(url);
            IEnumerable<XElement> Users = root.Elements("User");

            // e kqyr a ka user me kit username
            IEnumerable<XElement> currentUsers =
              from el in Users
              where (string)el.Attribute("username") == username
              select el;

            if (currentUsers.Count() == 0)
            {
                Debug.WriteLine("ERROR");
            }
            else
            {
                string userSalt = currentUsers.First().Attribute("salt").Value.ToString();
                string hashedPw = currentUsers.First().Attribute("hashedpw").Value.ToString();

                Hash user1 = new(userSalt, hashedPw);

                if (user1.CheckUser(password))
                {
                    user1 = null;
                    Debug.WriteLine("OK");
                }
                else
                {
                    user1 = null;
                    Debug.WriteLine("ERROR");
                }

            }

        }
        private void InsertData(string username, string tipi, string viti, string muaji, string qmimi, string url)
        {
            XElement root = XElement.Load(url);
            IEnumerable<XElement> Users = root.Elements("User");

            IEnumerable<XElement> currentUser =
              from el in Users
              where (string)el.Attribute("username") == username
              select el;
            IEnumerable<XElement> Shpenzimet = currentUser.Elements("Shpenzimet");
            if (Shpenzimet.Count() == 0)
            {
                currentUser.First().Add(new XElement("Shpenzimet",
                  new XElement("Shpenzimi",
                    new XAttribute("tipi", tipi),
                    new XAttribute("viti", viti),
                    new XAttribute("muaji", muaji),
                    new XAttribute("qmimi", qmimi)
                  )));
                root.Save(url);
                Debug.WriteLine("OK");
            }
            else
            {
                Debug.WriteLine(Shpenzimet.First());
                Shpenzimet.First().AddFirst(new XElement("Shpenzimi",
                  new XAttribute("tipi", tipi),
                  new XAttribute("viti", viti),
                  new XAttribute("muaji", muaji),
                  new XAttribute("qmimi", qmimi)));

                root.Save(url);
                Debug.WriteLine("OK");

            }

        }

        private void GetData(string url, string username)
        {
            XElement root = XElement.Load(url);
            IEnumerable<XElement> Users = root.Elements("User");

            IEnumerable<XElement> currentUser =
              from el in Users
              where (string)el.Attribute("username") == username
              select el;
            if (currentUser.Elements("Shpenzimet").Count() == 0)
            {
                Debug.WriteLine("me i kallxu qe ska");
            }
            else
            {
                string result = "";
                foreach (XElement user in currentUser.Elements("Shpenzimet"))
                {
                    result += user.ToString();
                }

                // qetu me qu
                Debug.WriteLine(result);
            }
        }

    }
}