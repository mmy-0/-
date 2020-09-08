namespace RJ02D201812022328EP
{
    partial class frmSetnicheng
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
            this.button2 = new System.Windows.Forms.Button();
            this.btnCofirm = new System.Windows.Forms.Button();
            this.txtNicheng = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(266, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnCofirm
            // 
            this.btnCofirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCofirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCofirm.Location = new System.Drawing.Point(88, 118);
            this.btnCofirm.Name = "btnCofirm";
            this.btnCofirm.Size = new System.Drawing.Size(80, 25);
            this.btnCofirm.TabIndex = 5;
            this.btnCofirm.Text = "确定";
            this.btnCofirm.UseVisualStyleBackColor = false;
            this.btnCofirm.Click += new System.EventHandler(this.btnCofirm_Click);
            // 
            // txtNicheng
            // 
            this.txtNicheng.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNicheng.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtNicheng.Location = new System.Drawing.Point(0, 0);
            this.txtNicheng.Multiline = true;
            this.txtNicheng.Name = "txtNicheng";
            this.txtNicheng.Size = new System.Drawing.Size(422, 95);
            this.txtNicheng.TabIndex = 4;
            this.txtNicheng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmSetnicheng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 159);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCofirm);
            this.Controls.Add(this.txtNicheng);
            this.Name = "frmSetnicheng";
            this.Text = "请在此修改昵称";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCofirm;
        private System.Windows.Forms.TextBox txtNicheng;
    }
}