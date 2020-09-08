using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electricity
{
    public partial class Logon : Form
    {
        private static Logon loginRegister = new Logon();
        
        private Logon()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        public static Logon getInstance()
        {
            return loginRegister;
        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Login.getInstance());

            System.Timers.Timer t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += TimeDisplay;
            t.AutoReset = true;
            t.Enabled = true;
            label1.ForeColor = Color.Gray;
        }

        private void button2_Click(object sender, EventArgs e)          //注册
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Register.getInstance());
            this.button2.ForeColor = Color.White;
            this.button2.BackColor = Color.DeepPink;

            this.button1.ForeColor = Color.Black;
            this.button1.BackColor = Color.SlateBlue;

        }

        private void button1_Click(object sender, EventArgs e)          //登录
        {
            //MessageBox.Show((loginRegister == null).ToString());
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Login.getInstance());
            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.DeepPink;

            this.button2.ForeColor = Color.Black;
            this.button2.BackColor = Color.SlateBlue;

        }

        private void TimeDisplay(object source, System.Timers.ElapsedEventArgs e)           //时间
        {
            label1.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
