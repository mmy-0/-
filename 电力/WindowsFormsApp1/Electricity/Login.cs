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
    public partial class Login : UserControl
    {
        public string username;
        private static Login login = new Login();

        private Login()
        {
            InitializeComponent();
        }

        public static Login getInstance()
        {
            return login;
        }

        //设置返回电卡

        private string binding_card;                        //电卡
        public string Card { get { return binding_card; } set { binding_card = value; } }
        //public int Car()
        //{
        //    int C=0;
        //    //-------------------------------------------------------************-------------------
        //    string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
        //    SqlConnection conn = new SqlConnection(Sqlstr);
        //    conn.Open();
        //    //-------------------------------------------------------************-------------------
        //    string sqlText = "select binding_card from Account1 where Login_ID='" + textBox1.Text + "'";

        //    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
        //    SqlDataReader reader = sqlCmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        C =Convert.ToInt32(reader[0]);
        //    }
        //    conn.Close();
        //    return C;
        //}

        public void setBinding_card(string card)
        {
            binding_card = card;
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("UPDATE Account1 SET binding_card = '" + card + "' WHERE Login_ID = '" + Login_ID + "'", con))
                {
                    com.ExecuteNonQuery();
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)          //登录
        {
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;

            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------


            string sqlText = "select count(*) from Account1 where Login_ID=@usersName and cipher=@usersPwd";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",textBox1.Text),
                new SqlParameter("@usersPwd",textBox2.Text)
            };

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (p != null)
                sqlCmd.Parameters.AddRange(p);

            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());////////////////

            if (i > 0)
            {
                //MessageBox.Show("有此人");
                //ParameterHelper.UserName = txtLogAccount.Text;
                using (SqlConnection connection = SQLManage.Connection())
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM Account1 where Login_ID='"+ textBox1.Text + "'", connection);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Num= reader[0].ToString();
                            Card = reader[5].ToString();
                        }
                    }
                }

                int d = 0;
                using (SqlConnection connection = SQLManage.Connection())
                {
                    connection.Open();
                    using (SqlCommand com = new SqlCommand("select Online_opening from ELECRIC_CARD where user_account = '" + Card + "'", connection))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                d = Convert.ToInt32(reader[0]);
                            }
                        }
                    }
                }


                if (d == 1)
                {
                    Logon.getInstance().panel4.Controls.Clear();
                    Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
                    MessageBox.Show("登录成功！");
                }
                if (d == 0)
                {
                    MessageBox.Show("您已被注销！请到电力公司激活！");
                }

                /* MessageBox.Show(Num);    */        //conn.Close();             
            }
            else
                MessageBox.Show("密码或账号错");

        }

        private void label3_Click(object sender, EventArgs e)           //忘记密码
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(ForgotPassword.getInstance());
        }

        //public string Num()
        //{
        //    string N = textBox1.Text;
        //    //if (textBox1.Text == "")
        //    //{
        //    //    N = null;
        //    //}
        //    return N;
        //}

        private string Login_ID;                            //账号
        public string Num { get { return Login_ID; } set { Login_ID = value; } }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
