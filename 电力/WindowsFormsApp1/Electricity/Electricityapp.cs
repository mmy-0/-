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
    public partial class Electricityapp : UserControl
    {
        private static Electricityapp ElectricityApp = new Electricityapp();
        public static Electricityapp getInstance()
        {
            return ElectricityApp;
        }
        public Electricityapp()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)//添加数据
        {
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                SqlCommand com = new SqlCommand("insert Electricityapp(Electricityname,user_account,Use_time,Salary)values" + "('" + comboBox1.SelectedItem.ToString() + "', '" + Login.getInstance().Card + "', '" + DateTime.Now.ToString() + "', 5)", connection);
                com.ExecuteNonQuery();
            }
        }
        private void button1_Click(object sender, EventArgs e)//返回
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
            AllPage.getInstance().panel3.Controls.Clear();
            AllPage.getInstance().panel3.Controls.Add(Service.getInstance());
        }

        private void Electricityapp_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection1 = SQLManage.Connection())
            {
                connection1.Open();
                SqlCommand com2 = new SqlCommand("select *from Electricityapp where user_account= '" + Login.getInstance().Card + "'", connection1);
                using (SqlDataReader reader1 = com2.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        comboBox1.Items.Add(reader1[0].ToString());
                    }
                }
                string sqlText2 = "select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='冰箱'";
                SqlCommand sqlCmd2 = new SqlCommand(sqlText2, connection1);
                using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        this.label4.Text = Convert.ToString(reader2[0]);
                    }
                }
            }
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("冰箱");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con2 = SQLManage.Connection())
            {
                con2.Open();
                using (SqlCommand com3 = new SqlCommand("select AVG(Salary)from Electricityapp where user_account= '" + Login.getInstance().Card + "' and Electricityname='" + comboBox1.SelectedItem.ToString() + "'", con2))
                {
                    using (SqlDataReader reader3 = com3.ExecuteReader())
                    {
                        while (reader3.Read())
                        {
                            this.label4.Text = Convert.ToString(reader3[0]);
                        }
                    }
                }
            }
        }
    }
}
