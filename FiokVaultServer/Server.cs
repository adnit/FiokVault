using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class Server
    {
        //SIGNUP?email=asdasd@ada.com&username=asdasdasd&gjinia=M&password=123123
        public static void SignUp(String username, String password)
        {

        }

        //INSERT?username=johndoe&tipi=Blerje&viti=2015&muaji=Mars&qmimi=2
        public static void InsertInfo(Shpenzimet shpenzim)
        {

        }

        //GETDATA?username=johndoe
        public static List<Shpenzimet> GetInfo()
        {

            return null;
        }

        //LOGIN?username=johndoe&password=123123123
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
