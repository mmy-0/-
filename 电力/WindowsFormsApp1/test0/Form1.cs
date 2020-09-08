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
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace test0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            MessageBox.Show(this.Height.ToString());
            //openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    string fullPath = openFileDialog1.FileName;
            //    using (SqlConnection connection = new SqlConnection
            //            ("Server=.;Database=Chuandian_on_palm;Trusted_Connection=True"))
            //    {
            //        connection.Open();

            //        SqlCommand command = new SqlCommand("update Account1 set head_sculpture=(select * from Openrowset(bulk '" + fullPath + "',single_blob) as a) where Login_ID = '18781714256'", connection);
            //        command.ExecuteNonQuery();
            //        MessageBox.Show("成功将图片存入SQL Server");
            //    }
            //using (FileStream fs = new FileStream(fullPath, FileMode.Open))
            //{
            //    //byte[] imagebytes = new byte[fs.Length];
            //    //BinaryReader br = new BinaryReader(fs);
            //    //imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));  
            //}
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Series series2 = new Series("series2");
            chart1.Series.Add(series2);
            chart1.Series["series2"].ChartType = SeriesChartType.Line;

            for (int i = 0; i < 10; i++)
            {
                chart1.Series["series2"].Points.AddXY(i * 10, i * 20);
            }

            chart1.ChartAreas["ChartArea1"].Name = "图表区域";
            chart1.ChartAreas["图表区域"].Position.Auto = true;//设置是否自动设置合适的图表元素
            chart1.ChartAreas["图表区域"].Position.X = 5.089137F;//设置图表元素左上角对应的X坐标
            chart1.ChartAreas["图表区域"].Position.Y = 5.895753F;//设置图表元素左上角对应的Y坐标
            chart1.ChartAreas["图表区域"].Position.Height = 86.76062F;//设置图表元素的高度

            chart1.ChartAreas["图表区域"].Position.Width = 88F;//设置图表元素的宽度



            chart1.ChartAreas["图表区域"].InnerPlotPosition.Auto = false;//设置是否在内部绘图区域中自动设置合适的图表元素

            chart1.ChartAreas["图表区域"].InnerPlotPosition.Height = 85F;//设置图表元素内部绘图区域的高度

            chart1.ChartAreas["图表区域"].InnerPlotPosition.Width = 86F;//设置图表元素内部绘图区域的宽度

            chart1.ChartAreas["图表区域"].InnerPlotPosition.X = 8.3969F;//设置图表元素内部绘图区域左上角对应的X坐标

            chart1.ChartAreas["图表区域"].InnerPlotPosition.Y = 3.63068F;//设置图表元素内部绘图区域左上角对应的Y坐标


            chart1.ChartAreas["图表区域"].AxisY.IsLabelAutoFit = false;//设置是否自动调整轴标签



            Legend l = new Legend();//初始化一个图例的实例

            l.Alignment = System.Drawing.StringAlignment.Near;//设置图表的对齐方式(中间对齐，靠近原点对齐，远离原点对齐)

            l.BackColor = System.Drawing.Color.Black;//设置图例的背景颜色

            l.DockedToChartArea = "ChartArea1";//设置图例要停靠在哪个区域上

            l.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;//设置停靠在图表区域的位置(底部、顶部、左侧、右侧)

            l.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置图例的字体属性

            l.IsTextAutoFit = true;//设置图例文本是否可以自动调节大小

            l.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;//设置显示图例项方式(多列一行、一列多行、多列多行)

            l.Name = "l1";//设置图例的名称

            chart1.Legends.Add(l.Name);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.panel1.Height.ToString());
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

