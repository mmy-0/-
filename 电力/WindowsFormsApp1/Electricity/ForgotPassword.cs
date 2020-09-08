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
    public partial class ForgotPassword : UserControl
    {
        private static ForgotPassword forgotPassword = new ForgotPassword();
        private ForgotPassword()
        {
            InitializeComponent();
        }

        public static ForgotPassword getInstance()
        {
            return forgotPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox2.Text;
            string s1 = txtAccount.Text;
            string s2 = txtPassword.Text;
            string s3 = txtSetPw.Text;
            string s4 = pan();
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            
            string sqlText = "select count(*) from Account1 where Login_ID=@usersName";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",txtAccount.Text),              
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
                    txtAccount.Focus();
                    return;
                }

                if (!string.Equals(s2, s3))
                {
                    MessageBox.Show("两次密码不相同");
                    txtSetPw.Focus();
                    return;
                }
     
                string sqlText2 = "update Account1 set cipher = @password where Login_ID ='" + txtAccount.Text + "'";
                SqlParameter[] sp = new SqlParameter[]
              {
               new SqlParameter("@password",txtSetPw.Text),
              };
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn);
                if (sp != null)
                    sqlCmd2.Parameters.AddRange(sp);
               sqlCmd2.ExecuteNonQuery();

                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(Logon2.getInstance());

                conn.Close();

            }
            else
                MessageBox.Show("没有此账号");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = pan();
            MessageBox.Show("验证码为:"+s);
            textBox2.Text = s;
        }
        public string pan()
        {
            Random rd = new Random();
            string temp = Convert.ToString(rd.Next(100000));
            return temp;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
