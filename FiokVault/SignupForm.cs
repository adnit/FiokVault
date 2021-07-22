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
using System.Diagnostics;


namespace FiokVault
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            gjiniaBox.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                validateEmail();
                validateUserName();
                validatePw();
                validateGender();
                sendRequest();
            }
            catch (Exception ex)
            {
                signupBtn.Enabled = false;
                warning.Text = ex.Message;
            }
        }

        private void sendRequest()
        {
            string command
                    = "SIGNUP"
                    + "?email=" + emailTxt.Text
                    + "&username=" + usernameTxt.Text
                    + "&gjinia=" + gjiniaBox.SelectedItem.ToString()
                    + "&password=" + password.Text;
            try
            {
                string response = TCPClient.sendMessage(command);
                if (response == "OK")
                {
                    SessionStorage.username = usernameTxt.Text;
                    Close();
                }
                else if (response == "ERROR")
                {
                    throw new Exception("Emri i perdoruesit ose fjalekalimi jane gabim");
                }
                else
                {
                    throw new Exception("Ka ndodhur nje gabim kontaktoni adminin");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void validateGender()
        {
            if(gjiniaBox.SelectedIndex != -1)
            { 
            }
            else
            {
                throw new Exception("Zgjedhni gjinine tuaj");
            }
        }
        private void validatePw()
        {
            if (password.Text != confirmPw.Text)
            {
                throw new Exception("Fjalekalimi duhet te jete i njejte");
            }
            else if (password.Text.Length < 6)
            {
                throw new Exception("Fjalekalimi duhet te kete\n6 ose me shume karaktere");
            }
        }
        private void validateEmail()
        {
            var emReg = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            Regex emailReg = new(emReg);
            Match emailMatch = emailReg.Match(emailTxt.Text);

            if (emailMatch.Success)
            {
            }
            else
            {
                throw new Exception("Shkruani emailin valid");
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
                throw new Exception("Username duhet te kete\nvetem shkronja dhe numra");
            }else if (username.Length == 0)
            { 
                throw new Exception("Ju lutem shkruani username");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            try
            {
                validatePw();
                signupBtn.Enabled = true;
                warning.Text = String.Empty;
            }
            catch (Exception ex)
            {
                signupBtn.Enabled = false;
                warning.Text = ex.Message;
            }
            
        }
        private void confirmPw_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validatePw();
                signupBtn.Enabled = true;
                warning.Text = String.Empty;
            }
            catch (Exception ex)
            {
                signupBtn.Enabled = false;
                warning.Text = ex.Message;
            }
            
        }
        private void emailTxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validateEmail();
                signupBtn.Enabled = true;
                warning.Text = String.Empty;
            }
            catch (Exception ex)
            {
                signupBtn.Enabled = false;
                warning.Text = ex.Message;
            }
            
        }
        private void gjiniaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validateGender();
                signupBtn.Enabled = true;
                warning.Text = String.Empty;
            }
            catch (Exception ex)
            {
                signupBtn.Enabled = false;
                warning.Text = ex.Message;
            }
            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validateUserName();
                signupBtn.Enabled = true;
                warning.Text = String.Empty;
            }
            catch (Exception ex)
            {
                signupBtn.Enabled = false;
                warning.Text = ex.Message;
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
