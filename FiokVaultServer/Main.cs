using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiokVaultServer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            txtServerOutput.Text = "Server started!\r\nClient connected.\r\nClient connected.\r\nClient connected.";
            lbClientIP.Items.Add("198.14.32.1");
            lbClientIP.Items.Add("198.14.32.2");
            lbClientIP.Items.Add("198.14.32.3");
        }
    }
}
