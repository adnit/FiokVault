
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
            this.pnlServer = new System.Windows.Forms.Panel();
            this.mtbAddress = new System.Windows.Forms.MaskedTextBox();
            this.txtServerOutput = new System.Windows.Forms.TextBox();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.lblServer = new System.Windows.Forms.Label();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.lblClient = new System.Windows.Forms.Label();
            this.lbClientIP = new System.Windows.Forms.ListBox();
            this.btnClientDisconnect = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.pnlServer.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlServer
            // 
            this.pnlServer.Controls.Add(this.btnCopy);
            this.pnlServer.Controls.Add(this.mtbAddress);
            this.pnlServer.Controls.Add(this.txtServerOutput);
            this.pnlServer.Controls.Add(this.btnStopServer);
            this.pnlServer.Controls.Add(this.btnStartServer);
            this.pnlServer.Controls.Add(this.lblServer);
            this.pnlServer.Location = new System.Drawing.Point(12, 12);
            this.pnlServer.Name = "pnlServer";
            this.pnlServer.Size = new System.Drawing.Size(342, 346);
            this.pnlServer.TabIndex = 0;
            // 
            // mtbAddress
            // 
            this.mtbAddress.Location = new System.Drawing.Point(3, 26);
            this.mtbAddress.Mask = "990\\.990\\.990\\.990\\:99990";
            this.mtbAddress.Name = "mtbAddress";
            this.mtbAddress.PromptChar = '0';
            this.mtbAddress.Size = new System.Drawing.Size(334, 23);
            this.mtbAddress.TabIndex = 6;
            // 
            // txtServerOutput
            // 
            this.txtServerOutput.AcceptsReturn = true;
            this.txtServerOutput.AcceptsTab = true;
            this.txtServerOutput.Enabled = false;
            this.txtServerOutput.Location = new System.Drawing.Point(3, 55);
            this.txtServerOutput.Multiline = true;
            this.txtServerOutput.Name = "txtServerOutput";
            this.txtServerOutput.ReadOnly = true;
            this.txtServerOutput.Size = new System.Drawing.Size(334, 259);
            this.txtServerOutput.TabIndex = 2;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Enabled = false;
            this.btnStopServer.Location = new System.Drawing.Point(181, 320);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(75, 23);
            this.btnStopServer.TabIndex = 5;
            this.btnStopServer.Text = "Stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnStartServer
            // 
            this.btnStartServer.Location = new System.Drawing.Point(262, 320);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(75, 23);
            this.btnStartServer.TabIndex = 3;
            this.btnStartServer.Text = "Start";
            this.btnStartServer.UseVisualStyleBackColor = true;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
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
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.lblClient);
            this.pnlClient.Controls.Add(this.lbClientIP);
            this.pnlClient.Controls.Add(this.btnClientDisconnect);
            this.pnlClient.Location = new System.Drawing.Point(360, 12);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(253, 346);
            this.pnlClient.TabIndex = 1;
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
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(3, 320);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 23);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 370);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlServer);
            this.Name = "Main";
            this.Text = "Main";
            this.pnlServer.ResumeLayout(false);
            this.pnlServer.PerformLayout();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.TextBox txtServerOutput;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Button btnClientDisconnect;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ListBox lbClientIP;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.MaskedTextBox mtbAddress;
        private System.Windows.Forms.Button btnCopy;
    }
}