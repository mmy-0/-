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
    public partial class Electricityapp2 : UserControl
    {
        private static Electricityapp2 ElectricityApp2 = new Electricityapp2();
        public static Electricityapp2 getInstance()
        {
            return ElectricityApp2;
        }
        public Electricityapp2()
        {
            InitializeComponent();
        }

        private void Electricityapp2_Load(object sender, EventArgs e)
        {
            //using (SqlConnection connection1 = SQLManage.Connection())
            //{
            //    connection1.Open();
            //string sqlText2 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='冰箱'";
            //SqlCommand sqlCmd2 = new SqlCommand(sqlText2, connection1);
            //using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
            //{
            //    while (reader2.Read())
            //    {
            //        this.label10.Text = Convert.ToString(reader2[0]);
            //    }
            //}

            //string sqlText = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='空调'";
            //SqlCommand sqlCmd = new SqlCommand(sqlText, connection1);
            //using (SqlDataReader reader = sqlCmd.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {
            //        this.label8.Text = Convert.ToString(reader[0]);
            //    }
            //}

            //string sqlText1 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='洗衣机'";
            //SqlCommand sqlCmd1 = new SqlCommand(sqlText1, connection1);
            //using (SqlDataReader reader1 = sqlCmd1.ExecuteReader())
            //{
            //    while (reader1.Read())
            //    {
            //        this.label6.Text = Convert.ToString(reader1[0]);
            //    }
            //}

            //string sqlText3 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='其它设备'";
            //SqlCommand sqlCmd3 = new SqlCommand(sqlText3, connection1);
            //using (SqlDataReader reader3 = sqlCmd3.ExecuteReader())
            //{
            //    while (reader3.Read())
            //    {
            //        this.label12.Text = Convert.ToString(reader3[0]);
            //    }
            //}
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = pan2();
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                SqlCommand com = new SqlCommand("insert Electricityapp(Electricityname,user_account,Use_time,Salary)values" + "('洗衣机', '" + Login.getInstance().Card + "', '" + DateTime.Now.ToString() + "', '" + s + "')", connection);
                com.ExecuteNonQuery();
            }

            using (SqlConnection connection2 = SQLManage.Connection())
            {
                connection2.Open();
                SqlCommand com2 = new SqlCommand("update ELECRIC_CARD set surplus-='" + s + "' where user_account='" + Login.getInstance().Card + "'", connection2);
                com2.ExecuteNonQuery();
            }
            MessageBox.Show("启动成功！已开启自动调节模式！");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s2 = pan2();
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                SqlCommand com = new SqlCommand("insert Electricityapp(Electricityname,user_account,Use_time,Salary)values" + "('空调', '" + Login.getInstance().Card + "', '" + DateTime.Now.ToString() + "', '" + s2 + "')", connection);
                com.ExecuteNonQuery();
            }

            using (SqlConnection connection2 = SQLManage.Connection())
            {
                connection2.Open();
                SqlCommand com2 = new SqlCommand("update ELECRIC_CARD set surplus-='" + s2 + "' where user_account='" + Login.getInstance().Card + "'", connection2);
                com2.ExecuteNonQuery();
            }
            MessageBox.Show("启动成功！已开启自动调节模式！");
        }

        public string pan2()
        {
            Random rd2 = new Random();
            string temp2 = Convert.ToString(rd2.Next(0, 15));
            return temp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s3 = pan2();
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                SqlCommand com = new SqlCommand("insert Electricityapp(Electricityname,user_account,Use_time,Salary)values" + "('冰箱', '" + Login.getInstance().Card + "', '" + DateTime.Now.ToString() + "', '" + s3 + "')", connection);
                com.ExecuteNonQuery();
            }

            using (SqlConnection connection2 = SQLManage.Connection())
            {
                connection2.Open();
                SqlCommand com2 = new SqlCommand("update ELECRIC_CARD set surplus-='" + s3 + "' where user_account='" + Login.getInstance().Card + "'", connection2);
                com2.ExecuteNonQuery();
            }
            MessageBox.Show("启动成功！已开启自动调节模式！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
            AllPage.getInstance().panel3.Controls.Clear();
            AllPage.getInstance().panel3.Controls.Add(Service.getInstance());
        }

        private void Electricityapp2_Paint(object sender, PaintEventArgs e)
        {
            int a, b, c, d;
            a = Pan("select * from Electricityapp where user_account = '" + Login.getInstance().Card + "' and Electricityname = '冰箱'");
            if (a > 0)
            {
                this.label10.Text = FZ("select AVG(Salary)from Electricityapp where user_account = '" + Login.getInstance().Card + "' and Electricityname = '冰箱'").ToString("0.00");
            }
            else
                this.label10.Text = "0";         
            b = Pan("select * from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='空调'");
            if(b>0)
            {
                this.label8.Text = FZ("select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='空调'").ToString("0.00");
            }
            else
                this.label8.Text = "0";
            c = Pan("select * from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='洗衣机'");
            if (c > 0)
            {
                this.label6.Text = FZ("select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='洗衣机'").ToString("0.00");
            }
            else
                this.label6.Text = "0";
            d = Pan("select * from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='其它设备'");
            if(d>0)
            {
                this.label12.Text = FZ("select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='其它设备'").ToString("0.00");
            }
            else
                this.label12.Text = "0";
            //using (SqlConnection connection2 = SQLManage.Connection())
            //{
            //    connection2.Open();
            //    string sqlText2 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='冰箱'";
            //    SqlCommand sqlCmd2 = new SqlCommand(sqlText2, connection2);
            //    using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
            //    {
            //        int n = 0;
            //        while (reader2.Read())
            //        {
            //            n++;
            //        }
            //    }
            //    //if (n<0)
            //    //    this.label10.Text = "0";
            //    //else
            //    //{
            //    //    float f = Convert.ToSingle(reader2[0]);
            //    //    this.label10.Text = f.ToString("0.00");
            //    //}
            //    string sqlText = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='空调'";
            //    SqlCommand sqlCmd = new SqlCommand(sqlText, connection2);
            //    using (SqlDataReader reader = sqlCmd.ExecuteReader())
            //    {
            //        while (reader.Read())
            //        {
            //            float f = Convert.ToSingle(reader[0]);
            //            this.label8.Text = f.ToString("0.00");
            //        }
            //    }


            //    string sqlText1 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='洗衣机'";
            //    SqlCommand sqlCmd1 = new SqlCommand(sqlText1, connection2);
            //    using (SqlDataReader reader1 = sqlCmd1.ExecuteReader())
            //    {
            //        while (reader1.Read())
            //        {
            //            float f = Convert.ToSingle(reader1[0]);
            //            this.label6.Text = f.ToString("0.00");
            //        }
            //    }

            //    string sqlText3 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='其它设备'";
            //    SqlCommand sqlCmd3 = new SqlCommand(sqlText3, connection2);
            //    using (SqlDataReader reader3 = sqlCmd3.ExecuteReader())
            //    {
            //        while (reader3.Read())
            //        {
            //            float f = Convert.ToSingle(reader3[0]);
            //            this.label12.Text = f.ToString("0.00");
            //        }
            //    }
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s3 = pan2();
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                SqlCommand com = new SqlCommand("insert Electricityapp(Electricityname,user_account,Use_time,Salary)values" + "('其它设备', '" + Login.getInstance().Card + "', '" + DateTime.Now.ToString() + "', '" + s3 + "')", connection);
                com.ExecuteNonQuery();
            }

            using (SqlConnection connection2 = SQLManage.Connection())
            {
                connection2.Open();
                SqlCommand com2 = new SqlCommand("update ELECRIC_CARD set surplus-='" + s3 + "' where user_account='" + Login.getInstance().Card + "'", connection2);
                com2.ExecuteNonQuery();
            }
            MessageBox.Show("刷新成功");
        }

        public int Pan(string sql)
        {
            int N = 0;
            using (SqlConnection connection2 = SQLManage.Connection())
            {
                connection2.Open();
              //  string sqlText2 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='"+name+"'";
                SqlCommand sqlCmd2 = new SqlCommand(sql, connection2);
                using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        N++;
                    }
                }
            }
            return N;
        }

        public float FZ(string sql)
        {
            float A =0;
            using (SqlConnection connection2 = SQLManage.Connection())
            {
                connection2.Open();
                //  string sqlText2 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='"+name+"'";
                SqlCommand sqlCmd2 = new SqlCommand(sql, connection2);
                using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                         A = Convert.ToSingle(reader2[0]);
                    }
                }
            }
            return A;
        }
    }
}