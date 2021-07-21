using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FiokVault 
{
    
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            AcceptButton = loginBtn;
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
        }

        private void usernameTxt_TextChanged(object sender, EventArgs e)
        {
        
            removeSpaces();
            
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

            if(passwordTxt.TextLength < 6 || usernameTxt.TextLength < 4)
            {
                var result = MessageBox.Show("Emri i perdoruesit ose fjalekalimi jane gabim", "Gabim", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel)
                {
                    Close();
                }
            }
            else
            {
                string command = "login&username=" + usernameTxt.Text + "&password=" + passwordTxt.Text;
               
                try
                {
                    TCPClient.sendMessage(command);
                    string response = TCPClient.receiveMessage();
                    if(response == "OK")
                    {
                        // switch te main window
                    }else if(response == "ERROR")
                    {
                        throw new Exception("Emri i perdoruesit ose fjalekalimi jane gabim");
                    }else
                    {
                        throw new Exception("Ka ndodhur nje gabim kontaktoni adminin");
                    }
                }
                catch (Exception ex)
                {
                    var result = MessageBox.Show(ex.Message.ToString(), "Gabim", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        Close();
                    }
                }

            }
            
        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
