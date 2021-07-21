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
            
        }

        private void validatePw()
        {
            if(password.Text != confirmPw.Text)
            {
                warning.Text = "Fjalekalimi duhet te jete i njejte";
                signupBtn.Enabled = false;
            }else if(password.Text.Length < 6)
            {
                warning.Text = "Fjalekalimi duhet te kete 6 ose me shume karaktere";
                signupBtn.Enabled = false;
            }
            else
            {
                warning.Text = "";
                signupBtn.Enabled = true;
            }
        }

        private void validateUserName()
        {
            var usernameRg = "^[a-zA-Z0-9]+$";
            var username = usernameTxt.Text;

            Regex userRg = new Regex(usernameRg);
            Match userRgMatch = userRg.Match(username);
            if (!userRgMatch.Success && username.Length>0)
            {
                warning.Text = "Username duhet te kete vetem shkronja dhe numra";
                signupBtn.Enabled = false;
            }
            else
            {
                warning.Text = "";
                signupBtn.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validatePw();
        }
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            validateUserName();
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

        private void warning_Click(object sender, EventArgs e)
        {

        }

        private void confirmPw_TextChanged(object sender, EventArgs e)
        {
            validatePw();
        }
    }
}
