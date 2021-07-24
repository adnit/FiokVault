using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using FiokVaultServer;
using System.IO;
using System.Security.Cryptography;

namespace FiokVault
{

    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            AcceptButton = loginBtn;
            progressBar1.Visible = false;
            if (!String.IsNullOrEmpty(SessionStorage.username))
            {
                usernameTxt.Text = SessionStorage.username;
                ActiveControl = passwordTxt;
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            SignupForm signupForm = new SignupForm();
            signupForm.ShowDialog();
            signupForm.Dispose();
            Show();
            if (!String.IsNullOrEmpty(SessionStorage.username))
            {
                usernameTxt.Text = SessionStorage.username;
                ActiveControl = passwordTxt;
            }
        }

        private void removeSpaces()
        {
            usernameTxt.Text = usernameTxt.Text.Replace(" ", string.Empty);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            if (passwordTxt.TextLength < 6 || usernameTxt.TextLength < 4)
            {
                var result = MessageBox.Show("Emri i perdoruesit ose fjalekalimi jane gabim", "Gabim", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel)
                {
                    Close();
                }
            }
            else
            {
                string command =
                  "LOGIN" +
                  "?username=" + usernameTxt.Text +
                  "&password=" + passwordTxt.Text;
                progressBar1.Visible = true;
                progressBar1.Value = 45;
                try
                {
                    string response = TCPClient.sendMessage(command);
                    if (response == "OK")
                    {
                        SessionStorage.username = usernameTxt.Text;
                        Hide();
                        FiokVault fvault = new();
                        fvault.ShowDialog();
                        fvault.Dispose();
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
                catch (Exception ex)
                {
                    progressBar1.Value = 55;
                    createAccountLbl.Visible = false;
                    var result = MessageBox.Show(ex.Message.ToString(), "Gabim", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        Close();
                    }
                    else
                    {
                        progressBar1.Visible = false;
                        createAccountLbl.Visible = true;
                    }
                }
            }
        }
    }
}