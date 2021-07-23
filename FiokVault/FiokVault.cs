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
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;

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
            reload();
        }
        private void reload()
        {
            string command = "GETDATA?username=" + SessionStorage.username;

            try
            {
                string response = TCPClient.sendMessage(command);

                if (response.Length > 8)
                {
                    StringReader SR = new StringReader(command);

                    DataSet ds = new DataSet();
                    ds.ReadXml(SR);
                    dataGridView1.DataSource = ds.Tables[0];
                    label7.Visible = false;
                }
                else
                {
                    label7.Visible = true;
                }
            }
            catch(Exception ex)
            {
                label7.Text = ex.Message;
                label7.Visible = true;
            }
        } 
        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            reload();
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
                MessageBox.Show("Ju lutem plotesoni fushat e kerkuara");
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
                        reload();
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
       