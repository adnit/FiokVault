using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace FiokVault
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendUserInfo();
            var usernameRg = "^[a-zA-Z0-9]+$";
            var username = usernameTxt.Text;

            Regex userRg = new Regex(usernameRg);
            Match userRgMatch = userRg.Match(username);
            if (userRgMatch.Success)
            {
                if(password.Text == confirmPw.Text)
                {
                    sendUserInfo();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public const int SALT_SIZE = 16; // size in bytes
        public const int HASH_SIZE = 16; // size in bytes
        public const int ITERATIONS = 100000; // number of pbkdf2 iterations

        private void SaveInfo()
        {

            XDocument xmlDocument = XDocument.Load("FiokVault.xml");
            try
            {
                var root = xmlDocument.Root;
                var pages = root.Elements("User");
                var mypage = pages.Where(p => p.Attribute("salt").Value == "kripa").FirstOrDefault();
                XElement xNewChild = 
                    new XElement("User",
                    new XAttribute("username", "johndoe"),
                    new XAttribute("salt", "kripa"),
                    new XAttribute("hash", "hashi"));

                mypage.AddAfterSelf(xNewChild);
                xmlDocument.Save("FiokVault.xml");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public static byte[] CreateHash(string input)
        {
            RNGCryptoServiceProvider provider = new ();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);

            Rfc2898DeriveBytes pbkdf2 = new(input, salt, ITERATIONS);
            return pbkdf2.GetBytes(HASH_SIZE);
            // return salt;
        }
        private void sendUserInfo()
        {
            var str = Convert.ToBase64String(CreateHash("adnit"));
            result.Text = str;
            SaveInfo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void result_Click(object sender, EventArgs e)
        {

        }
    }
}
