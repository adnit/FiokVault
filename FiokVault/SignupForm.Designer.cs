﻿
namespace FiokVault
{
    partial class SignupForm
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
            this.password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.signupBtn = new System.Windows.Forms.Button();
            this.confirmPw = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.warning = new System.Windows.Forms.Label();
            this.gjiniaBox = new System.Windows.Forms.ComboBox();
            this.genderSelection = new System.Windows.Forms.Label();
            this.emailTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.Window;
            this.password.Location = new System.Drawing.Point(27, 320);
            this.password.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(281, 27);
            this.password.TabIndex = 3;
            this.password.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(27, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // usernameTxt
            // 
            this.usernameTxt.BackColor = System.Drawing.SystemColors.Window;
            this.usernameTxt.Location = new System.Drawing.Point(27, 251);
            this.usernameTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.usernameTxt.Name = "usernameTxt";
            this.usernameTxt.Size = new System.Drawing.Size(158, 27);
            this.usernameTxt.TabIndex = 1;
            this.usernameTxt.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 23F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sign up";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.Location = new System.Drawing.Point(55, 522);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(232, 20);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Already have account? Log in";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // signupBtn
            // 
            this.signupBtn.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signupBtn.Location = new System.Drawing.Point(81, 454);
            this.signupBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.signupBtn.Name = "signupBtn";
            this.signupBtn.Size = new System.Drawing.Size(173, 52);
            this.signupBtn.TabIndex = 5;
            this.signupBtn.Text = "Sign up";
            this.signupBtn.UseVisualStyleBackColor = true;
            this.signupBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // confirmPw
            // 
            this.confirmPw.BackColor = System.Drawing.SystemColors.Window;
            this.confirmPw.Location = new System.Drawing.Point(27, 384);
            this.confirmPw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmPw.Name = "confirmPw";
            this.confirmPw.PasswordChar = '*';
            this.confirmPw.Size = new System.Drawing.Size(281, 27);
            this.confirmPw.TabIndex = 4;
            this.confirmPw.TextChanged += new System.EventHandler(this.confirmPw_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(27, 355);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Confirm password";
            // 
            // warning
            // 
            this.warning.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.warning.ForeColor = System.Drawing.Color.Red;
            this.warning.Location = new System.Drawing.Point(27, 415);
            this.warning.Name = "warning";
            this.warning.Size = new System.Drawing.Size(281, 37);
            this.warning.TabIndex = 15;
            this.warning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gjiniaBox
            // 
            this.gjiniaBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gjiniaBox.FormattingEnabled = true;
            this.gjiniaBox.Items.AddRange(new object[] {
            "M",
            "F",
            "Non-binary"});
            this.gjiniaBox.Location = new System.Drawing.Point(208, 251);
            this.gjiniaBox.Name = "gjiniaBox";
            this.gjiniaBox.Size = new System.Drawing.Size(100, 28);
            this.gjiniaBox.TabIndex = 2;
            // 
            // genderSelection
            // 
            this.genderSelection.AutoSize = true;
            this.genderSelection.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.genderSelection.Location = new System.Drawing.Point(203, 222);
            this.genderSelection.Name = "genderSelection";
            this.genderSelection.Size = new System.Drawing.Size(67, 23);
            this.genderSelection.TabIndex = 17;
            this.genderSelection.Text = "Gjinia";
            // 
            // emailTxt
            // 
            this.emailTxt.Location = new System.Drawing.Point(27, 192);
            this.emailTxt.Name = "emailTxt";
            this.emailTxt.Size = new System.Drawing.Size(281, 27);
            this.emailTxt.TabIndex = 0;
            this.emailTxt.TextChanged += new System.EventHandler(this.emailTxt_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(27, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 23);
            this.label5.TabIndex = 19;
            this.label5.Text = "Email";
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 599);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.emailTxt);
            this.Controls.Add(this.genderSelection);
            this.Controls.Add(this.gjiniaBox);
            this.Controls.Add(this.warning);
            this.Controls.Add(this.confirmPw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.signupBtn);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usernameTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SignupForm";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button signupBtn;
        private System.Windows.Forms.TextBox confirmPw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label warning;
        private System.Windows.Forms.ComboBox gjiniaBox;
        private System.Windows.Forms.Label genderSelection;
        private System.Windows.Forms.TextBox emailTxt;
        private System.Windows.Forms.Label label5;
    }
}