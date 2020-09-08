using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
using System.Data.SqlClient;

namespace 后台管理
{
    public partial class 用电查询 : UserControl
    {
        private static 用电查询 First1 = new 用电查询();
        public static 用电查询 getInstance()
        {
            return First1;
        }
        private List<int> x = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private List<float> y = new List<float>();
        private string option = "";

        //定义刷新图表的委托
        public delegate void RefreshChartDelegate(List<int> x, List<float> y, string type);
        public 用电查询()
        {
            InitializeComponent();
            Show_Chart();

        }
        private void Show_Chart()
        {
            chart1.Series.Clear();
            MyChart.AddSeries(chart1, "电费消费情况图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            MyChart.SetTitle(chart1, "电费消费情况图", new Font("微软雅黑", 12), Docking.Bottom, Color.FromArgb(46, 199, 201));
            MyChart.SetStyle(chart1, Color.Transparent, Color.White);
            MyChart.SetLegend(chart1, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            MyChart.SetXY(chart1, "月份", "用电量", StringAlignment.Far, Color.DarkBlue, Color.Black, AxisArrowStyle.SharpTriangle, 1, 20);
            MyChart.SetMajorGrid(chart1, Color.Gray, 20, 20);
        }

        private void First_Load(object sender, EventArgs e)
        {
            y.Clear();
            Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            d = MySqlManage.GetQuery("SELECT * FROM ELECRIC_CARD", 6);
            foreach (string key in d.Keys)
            {
                comboBox1.Items.Add(key);
            }

            using (SqlConnection connection = SQLManage.Connection())
            {
                //添加电卡
                connection.Open();
                //添加时间          注：HISTORICAL_ELECTRICITY无主键，因此不适合用MySqlManage类
                SqlCommand com2 = new SqlCommand("SELECT * FROM HISTORICAL_ELECTRICITY WHERE user_account = '" + comboBox1.Text + "'", connection);
                using (SqlDataReader reader1 = com2.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        comboBox2.Items.Add(reader1[13].ToString());
                    }
                }
                com2.Clone();
            }

            option = DateTime.Now.Year.ToString();                                             //选择的年份
            AddData();

            RefreshChart(x, y, "chart1");          
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf("2019");
        }

        /// <summary>
        /// 绘制图表的数据
        /// </summary>
        /// <param name="x">横坐标的集合</param>
        /// <param name="y">纵坐标的集合</param>
        /// <param name="type">表名</param>
        public void RefreshChart(List<int> x, List<float> y, string type)
        {
            if (this.chart1.InvokeRequired)
            {
                RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                this.Invoke(stcb, new object[] { x, y, type });
            }
            else
            {
                chart1.Series[0].Points.DataBindXY(x, y);
            }
        }
        /// <summary>
        /// combobox选中内容发生改变时，图表应发生相应的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            y.Clear();
            option = "";                                             //选择的年份

            for (int i = 0; i < this.comboBox2.Items.Count; i++)
            {
                if (comboBox2.SelectedItem == comboBox2.Items[i])
                {
                    option = comboBox2.SelectedItem.ToString();
                }
            }
            AddData();
            RefreshChart(x, y, "chart1");
        }

        /// <summary>
        /// comboBox1改变时和comboBox2产生联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                using (SqlCommand com2 = new SqlCommand("SELECT * FROM HISTORICAL_ELECTRICITY WHERE user_account = '" + comboBox1.SelectedItem.ToString() + "'", con))
                {
                    using (SqlDataReader reader = com2.ExecuteReader())
                    {
                        comboBox2.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader[13].ToString());
                        }
                    }
                }
            }
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf("2019");

            y.Clear();
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("SELECT * FROM HISTORICAL_ELECTRICITY WHERE user_account = '" + comboBox1.SelectedItem.ToString() + "'", connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[13].ToString() == "2019")
                            {
                                for (int i = 1; i <= 12; i++)
                                {
                                    y.Add((float)reader[i]);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            RefreshChart(x, y, "chart1");           
        }






        private void AddData()
        {
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("SELECT * FROM HISTORICAL_ELECTRICITY", connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[13].ToString() == option)
                            {
                                for (int i = 1; i <= 12; i++)
                                {
                                    y.Add((float)reader[i]);
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
