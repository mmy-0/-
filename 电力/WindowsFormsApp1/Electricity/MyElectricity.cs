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
    public partial class MyElectricity : UserControl
    {
        private static MyElectricity Electricity = new MyElectricity();
        public static MyElectricity getInstance()
        {
            return Electricity;
        }
        public MyElectricity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
        }

        private void MyElectricity_Paint(object sender, PaintEventArgs e)
        {
            float a1 = 1, a2 = 1, A;
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "select *from ELECRIC_CARD where user_account='" + Login.getInstance().Card + "'";

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    this.label2.Text = reader[1].ToString();
                    this.label4.Text = reader[3].ToString();
                    //this.label6.Text = reader[4].ToString();
                    this.label3.Text = "截止时间" + DateTime.Now.ToString();
                }
            }

            string sqlText2 = "select AVG(Salary)from Electricityapp where user_account='" + Login.getInstance().Card + "'";

            SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn);

            using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
            {

                while (reader2.Read())
                {
                    a1 = Convert.ToSingle(reader2[0]);
                }
            }

            string sqlText3 = "select surplus from ELECRIC_CARD where user_account='" + Login.getInstance().Card + "'";

            SqlCommand sqlCmd3 = new SqlCommand(sqlText3, conn);

            using (SqlDataReader reader3 = sqlCmd3.ExecuteReader())
            {

                while (reader3.Read())
                {
                    a2 = Convert.ToSingle(reader3[0]);
                }
            }

            if (a1 == 0)
            {
                this.label6.Text = a2.ToString();
            }
            else
            {
                A = a2 / a1;
                if(A<0)
                {
                    this.label6.Text = "已欠费！";
                }
                else
                this.label6.Text = A.ToString("0");
            }
            

        }

        private void MyElectricity_Load(object sender, EventArgs e)
        {
           int d= Electricityapp2.getInstance().Pan("select *from Electricityapp where user_account = '" + Login.getInstance().Card + "' and Month(GETDATE())-Month(Use_time) < 1");
            if (d >1 )
            {
                using (SqlConnection connection2 = SQLManage.Connection())
                {
                    connection2.Open();
                    string sqlText2 = "select sum(Salary)from Electricityapp where user_account = '" + Login.getInstance().Card + "' and Month(GETDATE())-Month(Use_time) < 1";
                    SqlCommand sqlCmd2 = new SqlCommand(sqlText2, connection2);
                    using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            progressBar1.Value = Convert.ToInt32(reader2[0]);
                        }
                    }
                }
            }
            else
                progressBar1.Value = 0;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(PayElectricity.getInstance());
        }
    }
}
