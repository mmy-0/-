using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electricity
{
    public partial class Logon2 : UserControl
    {
        private static Logon2 logon2 = new Logon2();
        public static Logon2 getInstance()
        {
            return logon2;
        }
        public Logon2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Login.getInstance());
            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.DeepPink;

            this.button2.ForeColor = Color.Black;
            this.button2.BackColor = Color.SlateBlue;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Register.getInstance());
            this.button2.ForeColor = Color.White;
            this.button2.BackColor = Color.DeepPink;

            this.button1.ForeColor = Color.Black;
            this.button1.BackColor = Color.SlateBlue;
        }

        private void Logon2_Load(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Login.getInstance());
        }
    }
}
