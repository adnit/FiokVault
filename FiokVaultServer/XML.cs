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
using System.IO;
using System.Web;

namespace FiokVaultServer
{
    class XML
    {
        public static List<User> loggedUsers = new List<User>();

        public static string XMLUrl = "Users.xml";
        public static string RegisterUser(User user)
        {
            XElement root = XElement.Load(XMLUrl);
            IEnumerable<XElement> Users = root.Elements("User");

            // e kqyr a ka user me kit username
            IEnumerable<XElement> currentUsers =
              from el in Users
              where (string)el.Attribute("username") == user.username
              select el;

            // userid
            string userID = (Users.Count() + 1).ToString();

            // salti

            Hash newUser = new(user.password);

            if (currentUsers.Count() == 0)
            {
                root.Add(new XElement("User",
                  new XAttribute("userid", userID),
                  new XAttribute("email", user.email),
                  new XAttribute("username", user.username),
                  new XAttribute("gjinia", user.gjinia),
                  new XAttribute("salt", newUser.salt),
                  new XAttribute("hashedpw", newUser.hashedpw)
                ));
                root.Save(XMLUrl);
                newUser = null;
                return "OK";
            }

            return "ERROR";

        }
        public static string LoginUser(User user)
        {
            XElement root = XElement.Load(XMLUrl);
            IEnumerable<XElement> Users = root.Elements("User");

            // e kqyr a ka user me kit username
            IEnumerable<XElement> currentUsers =
              from el in Users
              where (string)el.Attribute("username") == user.username
              select el;

            if (currentUsers.Count() == 0)
            {
                return "ERROR";
            }
            else
            {
                string userSalt = currentUsers.First().Attribute("salt").Value.ToString();
                string hashedPw = currentUsers.First().Attribute("hashedpw").Value.ToString();

                Hash user1 = new(userSalt, hashedPw);

                if (user1.CheckUser(user.password))
                {
                    user1 = null;
                    return "OK";
                    if (loggedUsers.IndexOf(user) < 0)
                        loggedUsers.Add(user);
                }
                else
                {
                    user1 = null;
                    return "ERROR";
                }

            }

        }
        public static string InsertData(string request)
        {
            var req = request.Substring(request.IndexOf('?') + 1);
            var parsed = HttpUtility.ParseQueryString(req);
            string username = parsed["username"];
            string tipi = parsed["tipi"];
            string viti = parsed["viti"];
            string muaji = parsed["muaji"];
            string cmimi = parsed["qmimi"];
            XElement root = XElement.Load(XMLUrl);
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
                    new XAttribute("muaji",muaji),
                    new XAttribute("qmimi",cmimi)
                  )));
                root.Save(XMLUrl);
                return "OK";
            }
            else
            {
                Shpenzimet.First().AddFirst(new XElement("Shpenzimi",
                  new XAttribute("tipi", tipi),
                  new XAttribute("viti", viti),
                  new XAttribute("muaji", muaji),
                  new XAttribute("qmimi", cmimi)));

                root.Save(XMLUrl);
                return "OK";

            }

        }
        public static string GetData(string username)
        {
            try
            {
                XElement root = XElement.Load(XMLUrl);
                IEnumerable<XElement> Users = root.Elements("User");

                IEnumerable<XElement> currentUser =
                  from el in Users
                  where (string)el.Attribute("username") == username
                  select el;

                  string result = "";
                  foreach (XElement xUser in currentUser)
                    {
                        result += xUser.ToString();
                  }
                  XmlDocument doc = new XmlDocument();
                  doc.LoadXml(result);
                SignXML cert = new();
                var test = cert.SignFile(doc);

                return test.OuterXml;
                
            }
            catch(Exception e)
            {
                return "ERROR";
            }
        }

    }
}