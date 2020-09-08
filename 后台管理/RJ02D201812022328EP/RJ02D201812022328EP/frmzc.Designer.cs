namespace RJ02D201812022328EP
{
    partial class frmzc
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
            this.btnResgister = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtSetPw = new System.Windows.Forms.TextBox();
            this.txtVerificode = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnResgister
            // 
            this.btnResgister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnResgister.FlatAppearance.BorderSize = 0;
            this.btnResgister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResgister.ForeColor = System.Drawing.Color.White;
            this.btnResgister.Location = new System.Drawing.Point(110, 264);
            this.btnResgister.Name = "btnResgister";
            this.btnResgister.Size = new System.Drawing.Size(239, 36);
            this.btnResgister.TabIndex = 19;
            this.btnResgister.Text = "注  册";
            this.btnResgister.UseVisualStyleBackColor = false;
            this.btnResgister.Click += new System.EventHandler(this.btnResgister_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(161, 214);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(178, 21);
            this.txtId.TabIndex = 16;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(161, 182);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 21);
            this.txtPassword.TabIndex = 17;
            // 
            // txtSetPw
            // 
            this.txtSetPw.Location = new System.Drawing.Point(161, 153);
            this.txtSetPw.Name = "txtSetPw";
            this.txtSetPw.Size = new System.Drawing.Size(178, 21);
            this.txtSetPw.TabIndex = 18;
            // 
            // txtVerificode
            // 
            this.txtVerificode.Location = new System.Drawing.Point(161, 123);
            this.txtVerificode.Name = "txtVerificode";
            this.txtVerificode.Size = new System.Drawing.Size(178, 21);
            this.txtVerificode.TabIndex = 15;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(161, 89);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(178, 21);
            this.txtAccount.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "身份证号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "确认密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "设置密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "验证码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "登录账号";
            // 
            // frmzc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 388);
            this.Controls.Add(this.btnResgister);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtSetPw);
            this.Controls.Add(this.txtVerificode);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmzc";
            this.Text = "frmzc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResgister;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtSetPw;
        private System.Windows.Forms.TextBox txtVerificode;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}