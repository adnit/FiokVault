
namespace FiokVaultServer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.txtServerOutput = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbClientIP = new System.Windows.Forms.ListBox();
            this.btnClientDisconnect = new System.Windows.Forms.Button();
            this.lblClient = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtServerPort);
            this.panel1.Controls.Add(this.btnStartServer);
            this.panel1.Controls.Add(this.txtServerOutput);
            this.panel1.Controls.Add(this.txtServerIP);
            this.panel1.Controls.Add(this.lblServer);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 346);
            this.panel1.TabIndex = 0;
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(238, 25);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(99, 23);
            this.txtServerPort.TabIndex = 4;
            // 
            // btnStartServer
            // 
            this.btnStartServer.Enabled = false;
            this.btnStartServer.Location = new System.Drawing.Point(262, 320);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 3;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            // 
            // txtServerOutput
            // 
            this.txtServerOutput.AcceptsReturn = true;
            this.txtServerOutput.AcceptsTab = true;
            this.txtServerOutput.Location = new System.Drawing.Point(3, 55);
            this.txtServerOutput.Multiline = true;
            this.txtServerOutput.Name = "txtServerOutput";
            this.txtServerOutput.ReadOnly = true;
            this.txtServerOutput.Size = new System.Drawing.Size(334, 259);
            this.txtServerOutput.TabIndex = 2;
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(3, 25);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(229, 23);
            this.txtServerIP.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(3, 7);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(39, 15);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbClientIP);
            this.panel2.Controls.Add(this.btnClientDisconnect);
            this.panel2.Controls.Add(this.lblClient);
            this.panel2.Location = new System.Drawing.Point(360, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 346);
            this.panel2.TabIndex = 1;
            // 
            // lbClientIP
            // 
            this.lbClientIP.FormattingEnabled = true;
            this.lbClientIP.ItemHeight = 15;
            this.lbClientIP.Location = new System.Drawing.Point(4, 55);
            this.lbClientIP.Name = "lbClientIP";
            this.lbClientIP.Size = new System.Drawing.Size(242, 259);
            this.lbClientIP.TabIndex = 3;
            // 
            // btnClientDisconnect
            // 
            this.btnClientDisconnect.Location = new System.Drawing.Point(171, 320);
            this.btnClientDisconnect.Name = "btnClientDisconnect";
            this.btnClientDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnClientDisconnect.TabIndex = 2;
            this.btnClientDisconnect.Text = "Disconnect";
            this.btnClientDisconnect.UseVisualStyleBackColor = true;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(4, 32);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(38, 15);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 370);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Main";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtServerOutput;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClientDisconnect;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ListBox lbClientIP;
        private System.Windows.Forms.TextBox txtServerPort;
    }
}