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
    public partial class Register : UserControl
    {
        private static Register register = new Register();
        private Register()
        {
            InitializeComponent();
        }

        public static Register getInstance()
        {
            return register;
        }

        private void button2_Click(object sender, EventArgs e)              //注册
        {
            string s1 = txtAccount.Text;
            string s2 = txtPassword.Text;
            string s3 = txtId.Text;
            string s4 = txtSetPw.Text;


            if (s1 == string.Empty || s2 == string.Empty || s3 == string.Empty)
            {
                MessageBox.Show("请输入完整信息");
                txtAccount.Focus();
                return;
            }

            if (!string.Equals(s2, s4))
            {
                MessageBox.Show("两次密码不相同");
                txtSetPw.Focus();
                return;
            }

            if (Regular.IsTelephone(txtAccount.Text))
            {
                if (Regular.IsPassword(txtPassword.Text))
                {
                    if (Regular.IsIdentification(txtId.Text))
                    {
                        int d = Electricityapp2.getInstance().Pan("select *from Account1 where Login_ID='" + txtAccount.Text + "'");
                        if (d < 1)
                        {
                            //---------------------------------------------------------------------------------////
                            //ADO.NET访问数据库一般方式（模式：简单，稳定，重复，结构性）
                            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                            SqlConnection conn = new SqlConnection(Sqlstr);
                            conn.Open();
                            //---------------------------------------------------------------------------------////          
                            //string sqlText = "insert into 账号表(登陆账号,密码,身份证号) values(7,7,7)";
                            //string sqlText=string.Format("insert into 账号表(登陆账号,密码,身份证号) values('{0}','{1}','{2}')",s1,s2,s3);

                            string sqlText = "insert Account1(Login_ID,cipher,ID_Number,pet_name,binding_card) values(@Account,@password,@id,'','')";
                            SqlParameter[] sp = new SqlParameter[]
                            {
                                    new SqlParameter("@Account",txtAccount.Text),
                                    new SqlParameter("@password",txtPassword.Text),
                                    new SqlParameter("@id",txtId.Text)

                            };
                            //---------------------------------------------------------------------------------////
                            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                            if (sp != null)
                                sqlCmd.Parameters.AddRange(sp);

                            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果

                            conn.Close();
                            //---------------------------------------------------------------------------------////

                            //---------------------------------------------------------------------------------////
                            if (i != 0)
                            //MessageBox.Show("chengong");
                            {
                                //添加默认图片
                                //---------------------------------------------------------------------------------////

                                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                                conn2.Open();
                                string sqlText2 = "update Account1 set head_sculpture=(select head_sculpture from Account1 where Login_ID='18111278172')where Login_ID='" + txtAccount.Text + "'";
                                //---------------------------------------------------------------------------------////
                                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                                sqlCmd2.ExecuteNonQuery();
                                conn2.Close();
                                Logon.getInstance().panel4.Controls.Clear();
                                Logon.getInstance().panel4.Controls.Add(Bangcard.getInstance());
                            }
                        }
                        else
                        {
                            MessageBox.Show("账号已经有人使用！");
                            textBox2.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("身份证号码格式错误！");
                    }
                }
                else
                {
                    MessageBox.Show("密码至少6位，且必须数字与字符混合！", "提示", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("请输入正确的手机号！", "提示", MessageBoxButtons.YesNo);
            }

        }
        public string Account()
        {
            return txtAccount.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = ForgotPassword.getInstance().pan();
            MessageBox.Show("验证码为:" + s);
            textBox2.Text = s;
        }
    }
}
