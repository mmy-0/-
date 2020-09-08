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
using System.Data.SqlClient;

namespace Electricity
{
    public partial class MainPage : UserControl
    {
        private List<int> x = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private List<float> y = new List<float>();
        //定义刷新图表的委托
        public delegate void RefreshChartDelegate(List<int> x, List<float> y, string type);

        private static MainPage handCD = new MainPage();
        private MainPage()
        {
            InitializeComponent();

            ////-------------------------------------------------------************-------------------
            //string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            //SqlConnection conn = new SqlConnection(Sqlstr);
            //conn.Open();
            ////-------------------------------------------------------************-------------------


            //string sqlText = "select *from Historical_Electricity,Account1 where Account1.binding_card=Historical_Electricity.user_account and Login_ID='" + Login.getInstance().Num() + "'";

            //SqlCommand sqlCmd = new SqlCommand(sqlText, conn);

            //SqlDataReader reader = sqlCmd.ExecuteReader();

            //float[] arr;
            //arr = new float[12];
            //while (reader.Read())
            //{
            //    for(int i=0,j=1;i<arr.Length;i++,j++)
            //    {
            //        arr[i] =Convert.ToSingle(reader[j]);
            //    }
            //}
            //conn.Close();
            //Series series = chart1.Series[0];
            //// 画样条曲线（Spline）
            //series.ChartType = SeriesChartType.Spline;
            //// 线宽2个像素
            //series.BorderWidth = 1;
            //// 线的颜色：红色
            //series.Color = System.Drawing.Color.Red;
            //// 图示上的文字
            //series.LegendText = "用电量（度）";
            ////chart1.Titles.Add("");

            //// 准备数据
            ////float[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29, 90, 98 };

            //// 在chart中显示数据
            //int x = 1;
            //foreach (float v in arr)
            //{
            //    series.Points.AddXY(x, v);
            //    x++;
            //}
            ////MessageBox.Show(arr[0].ToString());
            //chart1.ChartAreas["ChartArea1"].Name = "图表区域";
            //chart1.ChartAreas["图表区域"].Position.Auto = true;//设置是否自动设置合适的图表元素
            //chart1.ChartAreas["图表区域"].Position.X = 5.089137F;//设置图表元素左上角对应的X坐标
            //chart1.ChartAreas["图表区域"].Position.Y = 5.895753F;//设置图表元素左上角对应的Y坐标
            //chart1.ChartAreas["图表区域"].Position.Height = 86.76062F;//设置图表元素的高度

            //chart1.ChartAreas["图表区域"].Position.Width = 88F;//设置图表元素的宽度



            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Auto = false;//设置是否在内部绘图区域中自动设置合适的图表元素

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Height = 85F;//设置图表元素内部绘图区域的高度

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Width = 86F;//设置图表元素内部绘图区域的宽度

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.X = 8.3969F;//设置图表元素内部绘图区域左上角对应的X坐标

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Y = 3.63068F;//设置图表元素内部绘图区域左上角对应的Y坐标


            //chart1.ChartAreas["图表区域"].AxisY.IsLabelAutoFit = false;//设置是否自动调整轴标签
            //// 设置显示范围
            //ChartArea chartArea = chart1.ChartAreas[0];
            //chartArea.AxisX.Minimum = 1;
            //chartArea.AxisX.Maximum = 12;
            //chartArea.AxisY.Minimum = 0d;
            //chartArea.AxisY.Maximum = 1000d;
        }
        public static MainPage getInstance()
        {
            return handCD;
        }

        private void button1_Click(object sender, EventArgs e)          //一键购电
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(PayElectricity.getInstance());
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            Show_Chart();

            #region
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                //获取对应的年份的数据，添加到容器y中
                using (SqlCommand com = new SqlCommand("SELECT * FROM HISTORICAL_ELECTRICITY WHERE user_account = '" + Login.getInstance().Card + "'", connection))
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
            #endregion

            RefreshChart(x, y, "chart1");
        }

        /// <summary>
        /// 图表初始化
        /// </summary>
        private void Show_Chart()
        {
            chart1.Series.Clear();
            MyChart.AddSeries(chart1, "用电图表", SeriesChartType.SplineRange, Color.Blue, Color.Black, false);
            MyChart.SetTitle(chart1, DateTime.Now.Year.ToString() + "年", new Font("微软雅黑", 7), Docking.Bottom, Color.FromArgb(46, 199, 201));
            MyChart.SetStyle(chart1, Color.Transparent, Color.Black);
            MyChart.SetLegend(chart1, Docking.Top, StringAlignment.Center, Color.Transparent, Color.Blue);
            MyChart.SetXY(chart1, "月份", "用电量（度）", StringAlignment.Far, Color.DarkBlue, Color.Blue, AxisArrowStyle.SharpTriangle, 1, 10);
            MyChart.SetMajorGrid(chart1, Color.Gray, 15, 10);
        }

        /// <summary>
        /// 图表添加数据
        /// </summary>
        /// <param name="x">月份</param>
        /// <param name="y">用电量</param>
        /// <param name="type">图表名</param>
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

        private void MainPage_Paint(object sender, PaintEventArgs e)
        {
            float a1=1,a2=1,A;
            ////-------------------------------------------------------************-------------------
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
                    this.label1.Text = Convert.ToString(reader[1]);
                    this.label6.Text = Convert.ToString(reader[3]);
                    //this.label7.Text = Convert.ToString(reader[4]);
                    this.label2.Text = "截止时间" + DateTime.Now.ToString();
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
                this.label7.Text = a2.ToString();
            }
            else
            {
                A = a2 / a1;
                if (A < 0)
                {
                    this.label7.Text = "已欠费！";
                }
                else
                    this.label7.Text = A.ToString("0");
            }
            //string sqlText2 = "select *from Historical_Electricity,Account1 where Account1.binding_card=Historical_Electricity.user_account and Login_ID='" + Login.getInstance().Num + "'";

            //SqlCommand sqlCmd2 = new SqlCommand(sqlText2, conn);

            //float[] arr;
            //arr = new float[12];

            //using (SqlDataReader reader2 = sqlCmd2.ExecuteReader())
            //{
            //    while (reader2.Read())
            //    {
            //        for (int i = 0, j = 1; i < arr.Length; i++, j++)
            //        {
            //            arr[i] = Convert.ToSingle(reader2[j]);
            //        }
            //        break;
            //    }
            //}

            //Series series = chart1.Series[0];
            //// 画样条曲线（Spline）
            //series.ChartType = SeriesChartType.Spline;
            //// 线宽2个像素
            //series.BorderWidth = 1;
            //// 线的颜色：红色
            //series.Color = System.Drawing.Color.Red;
            //// 图示上的文字
            //series.LegendText = "用电量（度）";
            ////chart1.Titles.Add("");

            //// 准备数据
            ////float[] values = { 95, 30, 20, 23, 60, 87, 42, 77, 92, 51, 29, 90, 98 };

            //// 在chart中显示数据
            //int x = 1;
            //foreach (float v in arr)
            //{
            //    series.Points.AddXY(x, v);
            //    x++;
            //}
            //// MessageBox.Show(arr[0].ToString());
            //chart1.ChartAreas["ChartArea1"].Name = "图表区域";
            //chart1.ChartAreas["图表区域"].Position.Auto = true;//设置是否自动设置合适的图表元素
            //chart1.ChartAreas["图表区域"].Position.X = 5.089137F;//设置图表元素左上角对应的X坐标
            //chart1.ChartAreas["图表区域"].Position.Y = 5.895753F;//设置图表元素左上角对应的Y坐标
            //chart1.ChartAreas["图表区域"].Position.Height = 86.76062F;//设置图表元素的高度

            //chart1.ChartAreas["图表区域"].Position.Width = 88F;//设置图表元素的宽度



            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Auto = false;//设置是否在内部绘图区域中自动设置合适的图表元素

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Height = 85F;//设置图表元素内部绘图区域的高度

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Width = 86F;//设置图表元素内部绘图区域的宽度

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.X = 8.3969F;//设置图表元素内部绘图区域左上角对应的X坐标

            //chart1.ChartAreas["图表区域"].InnerPlotPosition.Y = 3.63068F;//设置图表元素内部绘图区域左上角对应的Y坐标


            //chart1.ChartAreas["图表区域"].AxisY.IsLabelAutoFit = false;//设置是否自动调整轴标签
            //// 设置显示范围
            //ChartArea chartArea = chart1.ChartAreas[0];
            //chartArea.AxisX.Minimum = 1;
            //chartArea.AxisX.Maximum = 12;
            //chartArea.AxisY.Minimum = 0d;
            //chartArea.AxisY.Maximum = 1000d;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}


