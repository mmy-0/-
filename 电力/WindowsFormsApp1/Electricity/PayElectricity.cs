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
    public partial class PayElectricity : UserControl
    {

        private static PayElectricity payElectricity = new PayElectricity();
        private PayElectricity()
        {
            InitializeComponent();
        }

        public static PayElectricity getInstance()
        {
            return payElectricity;
        }

        private void button12_Click(object sender, EventArgs e)         //返回掌上川电
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
            AllPage.getInstance().panel3.Controls.Add(MainPage.getInstance());
            //MainPage.getInstance().panel3.Controls.Add(HandCD.getInstance());

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '10')";
           
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i =sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=10 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();

                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "10";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '20')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=20 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "20";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '30')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=30 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "30";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '50')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=50 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "50";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '100')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=100 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "100";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '200')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=200 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "200";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '300')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=300 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "300";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '400')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=400 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "400";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '500')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=500 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "500";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time, '1000')";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString())
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+=1000 where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = "1000";
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "insert Payment_Details(user_account, Login_ID, pay_time, pay_money) values(@user_account, @Login_ID, @pay_time,@pay_money)";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@user_account",Login.getInstance().Card ),
                new SqlParameter("@Login_ID", Login.getInstance().Num),
                new SqlParameter("@pay_time",DateTime.Now.ToString()),
                new SqlParameter("@pay_money",textBox1.Text)
            };
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
            conn.Close();
            if (i != 0)
            {
                //-------------------------------------------------------************-------------------
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                //-------------------------------------------------------************-------------------
                string sqlText2 = "update ELECRIC_CARD set surplus+='"+ textBox1.Text + "' where user_account='" + Login.getInstance().Card + "'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);
                sqlCmd2.ExecuteNonQuery();
                conn2.Close();
                Logon.getInstance().panel4.Controls.Clear();
                Logon.getInstance().panel4.Controls.Add(ElecSuccess.getInstance());
                ElecSuccess.getInstance().label3.Text = textBox1.Text;
                ElecSuccess.getInstance().label4.Text = DateTime.Now.ToString();
            }
        }

        private void PayElectricity_Paint(object sender, PaintEventArgs e)
        {
            this.label6.Text = Login.getInstance().Card.ToString();
            this.label5.Text = DateTime.Now.ToString();

            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------
            string sqlText = "select surplus from ELECRIC_CARD where user_account='"+ Login.getInstance().Card + "'";

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                this.label4.Text = reader[0].ToString();
            }
            conn.Close();

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
