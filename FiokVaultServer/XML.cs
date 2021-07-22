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
    }
}
