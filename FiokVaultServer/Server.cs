using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class Server
    {
        public static void RegisterUser(String username, String password)
        {

        }

        private static bool VerifyLogin(string username, string password)
        {
            foreach(User user in XML.users)
            {
                if (user.username == username && user.password == password)
                    return true;
            }
            return false;
        }
    }
}
