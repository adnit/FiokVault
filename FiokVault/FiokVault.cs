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
            ds = new DataSet();
        }

        private void FiokVault_Load(object sender, EventArgs e)
        {
          reload();
        }
        DataSet ds;
        private static string ReadUserData(string input, string value)
        {
            int startIndex = input.IndexOf(value) + value.Length + 2;
            string output = input.Substring(startIndex, input.IndexOf('"', startIndex) - startIndex);
            return output;
        }
        private void reload()
        {
            string command = "GETDATA?username=" + SessionStorage.username;

            try
            {
                string rawResponse = TCPClient.sendMessage(command);
                int startIndex = rawResponse.IndexOf("<Shpenzimet>");
                string response = "";
                string userData = "";
                if (startIndex > 0)
                {
                    int endIndex = rawResponse.IndexOf("</Shpenzimet>") + 13;
                    response = rawResponse.Substring(rawResponse.IndexOf("<Shpenzimet>"), endIndex - startIndex);
                    userData = rawResponse.Substring(0, startIndex);
                }
                else
                {
                    response = "";
                    userData = rawResponse;
                }
                
                txtId.Text = ReadUserData(userData, "userid");
                txtEmail.Text = ReadUserData(userData, "email");
                txtUser.Text = ReadUserData(userData, "username");

                this.Text = "Dashboard - " + txtUser.Text;
                txtSex.Text = ReadUserData(userData, "gjinia");

                int start = rawResponse.IndexOf("<SignatureValue>");
                int end = rawResponse.IndexOf("</SignatureValue>");


                string hashVal = rawResponse.Substring(rawResponse.IndexOf("<SignatureValue>")+16, end-start-16);
                txtHash.Text = hashVal;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(rawResponse);
                VerifyXMLSignature cert = new();
                var test = cert.verifyFileSignature(doc);

                if (test) 
                    pbVerify.BackgroundImage = Properties.Resources.OK;
                else
                {
                    pbVerify.BackgroundImage = Properties.Resources.ERROR;
                    MessageBox.Show("Error");
                }
                    

                if (response.Length > 8)
                {
                    StringReader SR = new StringReader(response);
                    ds.Clear();
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
        private void reloadBtn_Click(object sender, EventArgs e)
        {
            reload();
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
                    = "INSERT" 
                    + "?username=" + SessionStorage.username
                    + "&tipi=" + comboBox1.SelectedItem.ToString()
                    + "&viti=" + vitiDropDown.Value.ToString()
                    + "&muaji=" + comboBox2.SelectedItem.ToString()
                    + "&qmimi=" + qmimi.ToString();
                Debug.WriteLine(command);
                try
                {
                    string response = TCPClient.sendMessage(command);
                    
                    if (response == "OK")
                    {
                        if (label7.Visible == false)
                        {
                            insert2Table(comboBox1.SelectedItem.ToString(), vitiDropDown.Value.ToString(), comboBox2.SelectedItem.ToString(), qmimi.ToString());
                        }
                        else reload();
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void insert2Table(string tipi, string viti, string muaji, string qmimi)
        {
            // ds.ReadXml(SR);
            // dataGridView1.DataSource = ds.Tables[0];
            // ds.Tables[0].Columns["tipi"].ColumnName = "Tipi";
            // dataGridView1.Rows.Insert(0, "six", "seven", "eight");
            var dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
           
            dr["tipi"] = tipi;
            dr["viti"] = viti;
            dr["muaji"] = muaji;
            dr["qmimi"] = qmimi;
            dt.Rows.InsertAt(dr, 0);
        }
    }
}
       