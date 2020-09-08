using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Electricity
{
    public partial class RevisePassword : UserControl
    {
        private static RevisePassword revisePassword = new RevisePassword();
        private RevisePassword()
        {
            InitializeComponent();
        }

        public static RevisePassword getInstance()
        {
            return revisePassword;
        }

        private void button3_Click(object sender, EventArgs e)                      //返回设置
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(Setting.getInstance());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Regular.IsPassword(textBox1.Text))
            {
                if (textBox1.Text.Equals(textBox2.Text))
                {
                    using (SqlConnection con = SQLManage.Connection())
                    {
                        con.Open();
                        string sql = "UPDATE Account1 SET cipher = '" + textBox1.Text + "' WHERE Login_ID = '" +Login.getInstance().Num + "'";
                        using (SqlCommand com = new SqlCommand(sql, con))
                        {
                            com.ExecuteNonQuery();
                        }
                        MessageBox.Show("密码修改成功！");
                    }
                }
                else
                {
                    MessageBox.Show("请确保两次输入密码相同！");
                }
            }
            else
            {
                MessageBox.Show("密码必须是字母和数字混合，且至少为6位");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                string sql = "UPDATE Account1 SET pet_name = '" + textBox3.Text + "' WHERE Login_ID = '" + Login.getInstance().Num + "'";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("昵称修改成功！");
            }
        }
    }
}
