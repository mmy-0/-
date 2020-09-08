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

namespace 后台管理
{
    public partial class 统计分析 : UserControl
    {
        private static 统计分析 congra = new 统计分析();
        public static 统计分析 getInstance()
        {
            return congra;
        }
        public 统计分析()
        {
            InitializeComponent();
        }
        private string option = "";
        private void 统计分析_Load(object sender, EventArgs e)
        {
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d = MySqlManage.GetQuery("SELECT distinct binding_address FROM ELECRIC_CARD ", 0);
            foreach (string key in d.Keys)
            {
                comboBox1.Items.Add(key);
            }

            MyDataGridBiew.DataConnection(dataGridView1, "SELECT * FROM ELECRIC_CARD where binding_address='" + comboBox1.Text + "'");


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            option = "";                                             

            for (int i = 0; i < this.comboBox1.Items.Count; i++)
            {
                if (comboBox1.SelectedItem == comboBox1.Items[i])
                {
                    option = comboBox1.SelectedItem.ToString();
                }
            }
            MyDataGridBiew.DataConnection(dataGridView1, "SELECT * FROM ELECRIC_CARD where binding_address='" + option + "'");

            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                using (SqlCommand com2 = new SqlCommand("select sum(January+February+March+April+May+June+July+August+September+October+November+December)as 总电量 from Historical_Electricity,ELECRIC_CARD where Historical_Electricity.user_account=ELECRIC_CARD.user_account and binding_address= '" + comboBox1.SelectedItem.ToString() + "'", con))
                {
                    using (SqlDataReader reader = com2.ExecuteReader())
                    {                       
                        while (reader.Read())
                        {
                            this.label2.Text = "总用电为 " + reader[0].ToString() + " 度";
                        }
                    }
                }
            }

            //select count(*) from ELECRIC_CARD where binding_address='上海电力有限公司' and surplus<0

            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                using (SqlCommand com2 = new SqlCommand("select count(*) from ELECRIC_CARD where binding_address='" + comboBox1.SelectedItem.ToString() + "' and surplus<0", con))
                {
                    using (SqlDataReader reader = com2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.label3.Text = "欠费人数 " + reader[0].ToString();
                        }
                    }
                }
            }

        }
    }
}
