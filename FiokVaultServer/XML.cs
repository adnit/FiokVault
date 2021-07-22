﻿using System;
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
<<<<<<< HEAD
        ////   public List<User> users = new List<User>();

        //public const int SALT_SIZE = 8;
        //public const int HASH_SIZE = 8;
        //public const int ITERATIONS = 100000;
        //public XML(String url)
        //{
        //    //  XElement root = XElement.Load(url);
        //    //  RegisterUser("sdsdsd", url);
        //    RegisterUser("adnit@brazzers.com", "adnitbishaotr", "M", "adnit123", url);

        //    //   IEnumerable<XElement> address =
        //    //       from el in root.Elements("User")
        //    //       where (string)el.Attribute("username") == "joh2ndoe"
        //    //       select el;
        //    //
        //    //   IEnumerable<XElement> shpenzimet = address.Elements("Shpenzimet").Elements("Shpenzimi");
        //    //   foreach (XElement el in shpenzimet)
        //    //   {
        //    //       Debug.WriteLine(el);
        //    //   }

        //}

        //public void RegisterUser(string email, string username, string gjinia, string password, string url)
        //{
        //    XElement root = XElement.Load(url);
        //    IEnumerable<XElement> Users = root.Elements("User");

        //    // e kqyr a ka user me kit username
        //    IEnumerable<XElement> currentUsers =
        //        from el in Users
        //        where (string)el.Attribute("username") == username
        //        select el;

        //    // userid
        //    string userID = Users.Count() + 1.ToString();

        //    // salti
        //    RNGCryptoServiceProvider provider = new();
        //    byte[] salt = new byte[SALT_SIZE];
        //    provider.GetBytes(salt);
        //    string saltStr = Convert.ToBase64String(salt);

        //    // hashedpw
        //    Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
        //    string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

        //    if (currentUsers.Count() == 0)
        //    {
        //        root.Add(new XElement("User",
        //            new XAttribute("userid", userID),
        //            new XAttribute("email", email),
        //            new XAttribute("username", username),
        //            new XAttribute("gjinia", gjinia),
        //            new XAttribute("salt", saltStr),
        //            new XAttribute("hashedpw", hashedpwStr)
        //            ));
        //        root.Save(url);
        //    }
        //    else
        //    {
        //        // 
        //    }
        //}
        //public void LoginUser(string username, string password, string url)
        //{
        //    XElement root = XElement.Load(url);
        //    IEnumerable<XElement> Users = root.Elements("User");

        //    // e kqyr a ka user me kit username
        //    IEnumerable<XElement> currentUsers =
        //        from el in Users
        //        where (string)el.Attribute("username") == username
        //        select el;


        //    if (currentUsers.Count() == 0)
        //    {
        //        // ERROR
        //    }
        //    else
        //    {

        //        // salti
        //        RNGCryptoServiceProvider provider = new();
        //        byte[] salt = new byte[SALT_SIZE];
        //        provider.GetBytes(salt);
        //        string saltStr = Convert.ToBase64String(salt);

        //        // hashedpw
        //        Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
        //        string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

        //    }

        //    // userid
        //    string userID = Users.Count() + 1.ToString();

        //    // salti
        //    RNGCryptoServiceProvider provider = new();
        //    byte[] salt = new byte[SALT_SIZE];
        //    provider.GetBytes(salt);
        //    string saltStr = Convert.ToBase64String(salt);

        //    // hashedpw
        //    Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
        //    string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

        //}


        //private void VerifyLogin()
        //{

        //}
=======
        public
        const int SALT_SIZE = 8;
        public
        const int HASH_SIZE = 8;
        public
        const int ITERATIONS = 100000;
        public XML(String url)
        {
            LoginUser("adni111tadnit", "adnitadnit", url);
            RegisterUser("test@test.com", "adni111tadnit", "M", "adnitadnit", url);
            InsertData("adni111tadnit", "BLerjeee", "20022", "janar", "2.2", url);
            GetData(url, "adni111tadnit");

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
            RNGCryptoServiceProvider provider = new();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);
            string saltStr = Convert.ToBase64String(salt);

            // hashedpw
            Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
            string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

            if (currentUsers.Count() == 0)
            {
                root.Add(new XElement("User",
                  new XAttribute("userid", userID),
                  new XAttribute("email", email),
                  new XAttribute("username", username),
                  new XAttribute("gjinia", gjinia),
                  new XAttribute("salt", saltStr),
                  new XAttribute("hashedpw", hashedpwStr)
                ));
                root.Save(url);
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

                // salti
                byte[] salt = Convert.FromBase64String(userSalt);
                // hashedpw
                Rfc2898DeriveBytes pbkdf2 = new(password, salt, ITERATIONS);
                string hashedpwStr = Convert.ToBase64String(pbkdf2.GetBytes(HASH_SIZE));

                if (hashedPw == hashedpwStr)
                {
                    Debug.WriteLine("OK");

                }
                else
                {
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

>>>>>>> 0519a0e9a0c8089eb10bcd02e68941478ba0f5f0
    }
}