using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiokVaultServer
{
    class XML
    {
        public List<User> users = new List<User>();
        public XML(String url)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(url, XmlReadMode.InferSchema);
            foreach (DataTable db in dataSet.Tables)
            {
                foreach (DataRow row in db.Rows)
                {
                  Debug.Write(row["name"].ToString() + row["surname"].ToString());

                }
            }
        }
        public void RegisterUser(String username, String password)
        {

        }

        private void VerifyLogin() 
        { 
        
        }
    }
}
