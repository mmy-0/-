using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 后台管理
{
    public partial class Form1 : Form
    {
        private static Form1 back_nanegement = new Form1();

        public static Form1 getInstance()
        {
            return back_nanegement;
        }
        public Form1()
        {
            InitializeComponent();
        }
        private List<float> y = new List<float>();

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(统计分析.getInstance());
            this.button4.ForeColor = Color.Black;
            this.button4.BackColor = Color.Red;

            this.button11.ForeColor = Color.White;
            this.button11.BackColor = Color.Transparent;

            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.Transparent;

            this.button3.ForeColor = Color.White;
            this.button3.BackColor = Color.Transparent;

            this.button10.Text = "统计分析";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(用电查询.getInstance());
            this.button11.ForeColor = Color.Black;
            this.button11.BackColor = Color.Red;

            this.button4.ForeColor = Color.White;
            this.button4.BackColor = Color.Transparent;

            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.Transparent;

            this.button3.ForeColor = Color.White;
            this.button3.BackColor = Color.Transparent;

            this.button10.Text = "用电查询";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(首页.getInstance());
            this.button3.ForeColor = Color.Black;
            this.button3.BackColor = Color.Red;

            this.label12.Text= DateTime.Now.ToString();

            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                using (SqlCommand com2 = new SqlCommand("select sum(January+February+March+April+May+June+July+August+September+October+November+December)as 总电量 from Historical_Electricity,ELECRIC_CARD where Historical_Electricity.user_account=ELECRIC_CARD.user_account", con))
                {
                    using (SqlDataReader reader = com2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.label3.Text = reader[0].ToString();
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(信息修改.getInstance());

            this.button1.ForeColor = Color.Black;
            this.button1.BackColor = Color.Red;

            this.button11.ForeColor = Color.White;
            this.button11.BackColor = Color.Transparent;

            this.button4.ForeColor = Color.White;
            this.button4.BackColor = Color.Transparent;

            this.button3.ForeColor = Color.White;
            this.button3.BackColor = Color.Transparent;

            this.button10.Text = "信息修改";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(首页.getInstance());

            this.button3.ForeColor = Color.Black;
            this.button3.BackColor = Color.Red;


            this.button11.ForeColor = Color.White;
            this.button11.BackColor = Color.Transparent;

            this.button4.ForeColor = Color.White;
            this.button4.BackColor = Color.Transparent;

            this.button1.ForeColor = Color.White;
            this.button1.BackColor = Color.Transparent;

            this.button10.Text = "首页";
        }

        private void button12_Click(object sender, EventArgs e)
        {
           
            //string date;
            //date = DateTime.Now.Year.ToString();
            //MessageBox.Show(date);
            //Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            //d = MySqlManage.GetQuery("SELECT * FROM ELECRIC_CARD", 6);
            //foreach (string key in d.Keys)
            //{
              
            //}
        }
    }
}
