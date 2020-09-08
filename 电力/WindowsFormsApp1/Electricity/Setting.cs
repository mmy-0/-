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
    public partial class Setting : UserControl
    {
        private static Setting setting = new Setting();
        private Setting()
        {
            InitializeComponent();
        }

        public static Setting getInstance()
        {
            return setting;
        }

        private void button3_Click(object sender, EventArgs e)                  //返回我的主页
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
            AllPage.getInstance().panel3.Controls.Clear();
            AllPage.getInstance().panel3.Controls.Add(MyPage.getInstance());
        }

        private void button1_Click(object sender, EventArgs e)                  //修改密码
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(RevisePassword.getInstance());
        }

        private void button2_Click(object sender, EventArgs e)                  //退出登录
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(Logon2.getInstance());
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            
        }

        private void Setting_Paint(object sender, PaintEventArgs e)
        {
            this.label3.Text = Login.getInstance().Num;
            this.label5.Text = MyPage.getInstance().Nam();
        }
    }
}
