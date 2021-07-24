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


            //Client
            string stringMessage = "testingString";
            byte[] byteMessage = Convert.FromBase64String(stringMessage);

            byte[] byteKey = TCPClient.generateSafeRandom(64);
            string stringKey = Convert.ToBase64String(byteKey);

            byte[] byteIV = TCPClient.generateSafeRandom(8);
            string stringIV = Convert.ToBase64String(byteKey);

            byte[] byteRSA = FiokVaultClientEncrypt.RSAEncrypt(byteMessage, FiokVaultClientEncrypt.getPublicParameters(File.ReadAllText("..\\..\\..\\certificate\\publickey.txt")), false);
            string stringRSA = Convert.ToBase64String(byteRSA);

            FiokVaultDES des = new FiokVaultDES(byteKey);
            byte[] byteDes = des.Encrypt(stringMessage);
            string stringDes = Convert.ToBase64String(byteDes);

            stringMessage = Encoding.GetEncoding("ISO-8859-1")
.GetString(byteIV) +"//+//" + Encoding.GetEncoding("ISO-8859-1")
.GetString(byteRSA) + "//+//" + Encoding.GetEncoding("ISO-8859-1")
.GetString(byteDes);
            byteMessage = Convert.FromBase64String(stringMessage);

        //byteMessage = Convert.FromBase64String(stringMessage);
        // byteMessage = Convert.FromBase64String(stringRSA);
        // byteMessage = Convert.FromBase64String(stringDes);


            Debug.WriteLine(stringMessage);

            ////Server
            //byteMessage


            //FiokVaultServerDecrypt fvsd = new FiokVaultServerDecrypt();
            //string decryptedMessage = Encoding.UTF8.GetString(fvsd.decryptMessage(encryptedMessage));
            //byte[] sentKey = fvsd.decryptedKey;



        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {
        }
        private void usernameTxt_KeyDown(object sender, KeyEventArgs e)
        {

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

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}