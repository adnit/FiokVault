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

namespace FiokVault 
{
    public partial class FiokVault : Form
    {
        public FiokVault()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            comboBox1.SelectedIndex = -1;
        }

        private void FiokVault_Load(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            string command = "GETDATA?username=" + SessionStorage.username;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



        private void qmimiTxt_TextChanged(object sender, EventArgs e)
        {

        }
        private void qmimiTxt_Leave(object sender, System.EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addNew_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex  == -1)
            {
                MessageBox.Show("make sure u select ");
            }else
            {
                double qmimi = (double)numericUpDown1.Value + (double)numericUpDown2.Value / 100;
                string command
                    = "INSERT?tipi="
                    + comboBox1.SelectedItem.ToString()
                    + "&viti=" + vitiDropDown.Value.ToString()
                    + "&muaji=" + comboBox2.SelectedItem.ToString()
                    + "&qmimi=" + qmimi.ToString();
                try
                {
                    string response = TCPClient.sendMessage(command);
                    
                    if (response == "OK")
                    {
                        // switch te main window
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
                    var result = MessageBox.Show(ex.Message.ToString(), "Gabim", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel)
                    {
                        Close();
                    }
                }
            }
        }
    }
}
       