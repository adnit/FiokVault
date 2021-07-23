using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class Server
    {
        ////SIGNUP?email=asdasd@ada.com&username=asdasdasd&gjinia=M&password=123123
        //public static void SignUp(String username, String password)
        //{

        //}

        ////INSERT?username=johndoe&tipi=Blerje&viti=2015&muaji=Mars&qmimi=2
        //public static void InsertInfo(Shpenzimet shpenzim)
        //{

        //}

        public static string ReadRequestValue(string input, string value)
        {
            value += "=";
            if (input.IndexOf(value) < 0)
                return "";

            int index = input.IndexOf(value) + value.Length;
            string output = "";

            if (input.IndexOf('&') < index)
                output = input.Substring(index, input.Length - index);
            else
                output = input.Substring(index, input.IndexOf('&') - index);

            return output;
        }

        public static string ReadRequestType(string input)
        {
            return input.Substring(0, input.IndexOf('?'));
        }

        ////LOGIN?username=johndoe&password=123123123

        public static User ReadLoginInfo(string input)
        {
         
            string username = ReadRequestValue(input, "username");
            string password = ReadRequestValue(input, "password");

            User output = new User();
            output.username = username;
            output.password = password;

            return output;
        }
        //SIGNUP?email=asdasd@ada.com&username=asdasdasd&gjinia=M&password=123123
        public static User ReadSignupInfo(string input)
        {
            string email = ReadRequestValue(input, "email");
            string username = ReadRequestValue(input, "username");
            string gjinia = ReadRequestValue(input, "gjinia");
            string password = ReadRequestValue(input, "password");

            User output = new User();
            output.username = username;
            output.password = password;
            output.email = email;
            output.gjinia = gjinia[0];

            return output;
        }


        //INSERT?username=johndoe&tipi=Blerje&viti=2015&muaji=Mars&qmimi=2
        public static User ReadInsertInfo(string input)
        {
            string username = ReadRequestValue(input, "username");
            string tipi = ReadRequestValue(input, "tipi");
            string viti = ReadRequestValue(input, "viti");
            string muaji = ReadRequestValue(input, "muaji");
            string cmimi = ReadRequestValue(input, "qmimi");

            User user = new User();
            user.username = username;

            Shpenzimet output = new Shpenzimet();
            output.tipi = tipi;
            output.viti = ushort.Parse(viti);
            output.muaji = muaji;
            output.cmimi = uint.Parse(cmimi);

            user.shpenzimet.Add(output);

            return user;
        }

    }
}
