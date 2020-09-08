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
    public partial class ElectricityManage : UserControl
    {
        private static ElectricityManage ElectricManage = new ElectricityManage();
        public static ElectricityManage getInstance()
        {
            return ElectricManage;
        }
        public ElectricityManage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AllPage.getInstance());
        }

        private void ElectricityManage_Paint(object sender, PaintEventArgs e)
        {
            this.label7.Text = Login.getInstance().Card;
            this.label4.Text = "截止时间" + DateTime.Now.ToString();

            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------
            string sqlText = "select * from ELECRIC_CARD where user_account='" + Login.getInstance().Card + "'";

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while (reader.Read())
            {
                this.label2.Text = reader[6].ToString();
                this.label3.Text = reader[3].ToString();
                this.label9.Text = reader[1].ToString();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(AddCar.getInstance());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int d = Electricityapp2.getInstance().Pan("select *from ELECRIC_CARD where Login_ID='" + Login.getInstance().Num + "'");
            if (d == 1)
            {
                MessageBox.Show("该用户只有一张电卡，不能删除！");
            }
            else
            {
                int T = Convert.ToInt32(this.label3.Text);
                if (T > 0)
                {
                    DialogResult dr = MessageBox.Show("当前余额大于零！是否解除带电卡！", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        using (SqlConnection con = SQLManage.Connection())
                        {
                            con.Open();
                            string sql = "delete ELECRIC_CARD where user_account='" + this.label7.Text + "'";
                            using (SqlCommand com = new SqlCommand(sql, con))
                            {
                                com.ExecuteNonQuery();
                            }
                            MessageBox.Show("解除成功！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("已取消");
                    }

                }
                else
                {
                    //using (SqlConnection con = SQLManage.Connection())
                    //{
                    //    con.Open();
                    //    string sql = "delete ELECRIC_CARD where user_account='" + this.label7.Text + "'";
                    //    using (SqlCommand com = new SqlCommand(sql, con))
                    //    {
                    //        com.ExecuteNonQuery();
                    //    }
                    MessageBox.Show("当前金额过少请到本地电力公司自主申请！");
                    // }
                }
            }
        }
    }
}
