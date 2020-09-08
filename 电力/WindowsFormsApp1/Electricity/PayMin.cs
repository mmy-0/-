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
    public partial class PayMin : UserControl
    {
        private static PayMin Min = new PayMin();
        public static PayMin getInstance()
        {
            return Min;
        }
        public PayMin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
        }

        private void PayMin_Paint(object sender, PaintEventArgs e)
        {

            this.label6.Text = "截止时间" + DateTime.Now.ToShortDateString();
            this.label9.Text = "截止时间" + DateTime.Now.ToShortDateString();
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
            //-------------------------------------------------------************-------------------
            
            string sqlText = "select top 4 *From  Payment_Details where user_account='" + Login.getInstance().Card + "'";
           SqlCommand sqlCmd = new SqlCommand(sqlText, conn);

            using (SqlDataReader reader = sqlCmd.ExecuteReader())
            {
                string[] arr;
                arr = new string[8];
                int k = 2;
                int i = 0, j = 1;
                while (reader.Read() && k <= 8)
                {
                    for (; i < k;)
                    {
                        arr[i] = Convert.ToString(reader[2]);
                        arr[j] = Convert.ToString(reader[3]);
                        i += 2; j += 2;
                    }
                    k += 2;
                }
                this.label11.Text = arr[0]; this.label15.Text = arr[4];
                this.label12.Text = arr[1]; this.label16.Text = arr[5];
                this.label13.Text = arr[2]; this.label17.Text = arr[6];
                this.label14.Text = arr[3]; this.label18.Text = arr[7];
            }
            string sqlText2 = "select  sum(pay_money) From  Payment_Details where user_account='" + Login.getInstance().Card + "'";
            SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn);
            using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
            {
                while (reader2.Read())
                {
                    this.label4.Text = Convert.ToString(reader2[0]);
                }
            }
            string sqlText3 = "select *from ELECRIC_CARD where user_account='" + Login.getInstance().Card + "'";
            SqlCommand sqlCmd3 = new SqlCommand(sqlText3, conn);
            using (SqlDataReader reader3 = sqlCmd3.ExecuteReader())
            {
                while (reader3.Read())
                {
                    this.label3.Text = Convert.ToString(reader3[1]);
                    this.label7.Text = Convert.ToString(reader3[3]);
                }
            }
            ////-------------------------------------------------------************-------------------
            ////string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            ////SqlConnection conn2 = new SqlConnection(Sqlstr2);
            ////conn2.Open();
            ////-------------------------------------------------------************-------------------

            ////string sqlText2 = "select  sum(pay_money) From  Payment_Details where user_account='" + Login.getInstance().Car() + "'";

            ////SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn2);

            ////using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
            ////{
            ////    while (reader2.Read())
            ////    {
            ////        this.label4.Text = Convert.ToString(reader2[0]);
            ////    }
            ////}
        }
    }
}
