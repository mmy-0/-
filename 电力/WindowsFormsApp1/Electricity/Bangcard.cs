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
    public partial class Bangcard : UserControl
    {
        private static Bangcard Car = new Bangcard();
        public static Bangcard getInstance()
        {
            return Car;
        }
        public Bangcard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            string s3 = textBox3.Text;
            string adrss = "德阳电力有限公司";
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "select count(*) from Account1 where Login_ID=@usersName";

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",textBox1.Text)
            };

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (p != null)
                sqlCmd.Parameters.AddRange(p);

            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());////////////////

            if (i > 0)
            {
                if (s1 == string.Empty || s2 == string.Empty || s3 == string.Empty)
                {
                    MessageBox.Show("请输入完整信息");
                    textBox1.Focus();
                    return;
                }

                //   string sqlText2 = "update Account1 set binding_card = @password where Login_ID ='" + textBox1.Text + "'";
                //   SqlParameter[] sp = new SqlParameter[]
                //{
                //  new SqlParameter("@password",textBox2.Text),
                //};
                //   SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn);
                //   if (sp != null)
                //       sqlCmd2.Parameters.AddRange(sp);
                //   sqlCmd2.ExecuteNonQuery();
                //   conn.Close();
                //   Logon.getInstance().panel4.Controls.Clear();
                //   Logon.getInstance().panel4.Controls.Add(Logon2.getInstance());
                int d = Electricityapp2.getInstance().Pan("select *from ELECRIC_CARD where user_account='" + textBox2.Text + "'");
                if (d < 1)
                {
                    using (SqlConnection connection1 = SQLManage.Connection())
                    {
                        connection1.Open();
                        SqlCommand com1 = new SqlCommand("update Account1 set binding_card = '" + textBox2.Text + "' where Login_ID ='" + textBox1.Text + "'", connection1);
                        com1.ExecuteNonQuery();
                    }
                    using (SqlConnection connection2 = SQLManage.Connection())
                    {
                        connection2.Open();
                        SqlCommand com2 = new SqlCommand(" insert ELECRIC_CARD(user_account, binding_address, Login_ID, surplus, Days_Remaining, Online_opening, nickname)values('" + textBox2.Text + "', '" + adrss + "', '" + textBox1.Text + "', '0', '0', 1,'" + textBox3.Text + "')", connection2);
                        com2.ExecuteNonQuery();
                    }
                    MessageBox.Show("绑定成功！");
                    Logon.getInstance().panel4.Controls.Clear();
                    Logon.getInstance().panel4.Controls.Add(Logon2.getInstance());
                }
                else
                {
                    MessageBox.Show("此卡已经有人绑定");
                    textBox2.Focus();
                    return;
                }
            }
            else
                MessageBox.Show("账号错误");

        




           
        }
    }
}
