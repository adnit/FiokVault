using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FiokVaultServer
{
    class XML
    {
        public List<User> users = new List<User>();
        public XML(String url)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(url, XmlReadMode.InferSchema);
            Debug.WriteLine("\n" + dataSet.Tables.Count.ToString() + "\n");
            DataTable table = dataSet.Tables["User"];

            foreach (DataRow row in table.Rows)
            {
                User user = new User();
                user.firstName = row["name"].ToString();
                user.lastName = row["surname"].ToString();
                user.username = row["username"].ToString();
                user.gjinia = row["gjinia"].ToString()[0];
                user.password = row["hashedpw"].ToString();
                users.Add(user);
            }

            table = dataSet.Tables["Shpenzimet"];
        }

        //private List<Shpenzimet> GetShpenzimet(int index)
        //{

        //}
        public void RegisterUser(String username, String password)
        {

        }

        private void VerifyLogin() 
        { 
        
        }
    }
}
