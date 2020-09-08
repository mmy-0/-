namespace RJ02D201812022328EP
{
    partial class frmElectriCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmElectriCard));
            this.IDguanlilabel = new System.Windows.Forms.Label();
            this.tianjiadianka = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IDguanlilabel
            // 
            this.IDguanlilabel.Font = new System.Drawing.Font("幼圆", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IDguanlilabel.Location = new System.Drawing.Point(155, 6);
            this.IDguanlilabel.Name = "IDguanlilabel";
            this.IDguanlilabel.Size = new System.Drawing.Size(100, 30);
            this.IDguanlilabel.TabIndex = 6;
            this.IDguanlilabel.Text = "电卡管理";
            this.IDguanlilabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tianjiadianka
            // 
            this.tianjiadianka.BackColor = System.Drawing.Color.Transparent;
            this.tianjiadianka.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tianjiadianka.BackgroundImage")));
            this.tianjiadianka.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tianjiadianka.FlatAppearance.BorderSize = 0;
            this.tianjiadianka.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tianjiadianka.Location = new System.Drawing.Point(377, 11);
            this.tianjiadianka.Name = "tianjiadianka";
            this.tianjiadianka.Size = new System.Drawing.Size(30, 25);
            this.tianjiadianka.TabIndex = 5;
            this.tianjiadianka.UseVisualStyleBackColor = false;
            this.tianjiadianka.Click += new System.EventHandler(this.tianjiadianka_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 20);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tianjiadianka);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.IDguanlilabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(422, 40);
            this.panel2.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 440);
            this.panel1.TabIndex = 9;
            // 
            // frmElectriCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 480);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmElectriCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmElectriCard";
            this.Load += new System.EventHandler(this.frmElectriCard_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label IDguanlilabel;
        private System.Windows.Forms.Button tianjiadianka;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;

    }
}