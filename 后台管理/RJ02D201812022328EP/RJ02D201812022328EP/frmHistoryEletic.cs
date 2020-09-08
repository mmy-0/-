using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    public partial class frmHistoryEletic : Form
    {
        public frmHistoryEletic()
        {
            InitializeComponent();
        }
        GraphEdit graphEdit;
        Color boardColor = Color.White;//指定绘制图的背景色         


        private void LoadingUI()
        {
            graphEdit = new GraphEdit(480, 300, boardColor, 6, 7);//x代表X轴刻度线数量    //y代表Y轴刻度线数量   
            //横水平边距           
            //竖垂直边距            
            graphEdit.AreasColor = Color.FromArgb(50, 255, 128, 0);         //画图区域颜色
            graphEdit.AreasColor = Color.White;
            graphEdit.GraphColor = Color.FromArgb(255, 128, 0);        //曲线颜色  
            graphEdit.GraphColor = Color.Green;
            graphEdit.AxisColor = Color.FromArgb(155, 255, 212);         //坐标轴颜色            
            graphEdit.ScaleColor = Color.FromArgb(200, 145, 245, 245);          //刻度线颜色   
            graphEdit.ScaleColor = Color.Silver;

        }
        private void Run()
        {
                Image image = graphEdit.GetCurrentGraph(this.GetBaseData());          
                Graphics g = this.panel2.CreateGraphics();  //指定使用那个控件来接受曲线图  
                //panel2.Font= new Font("微软雅黑", 10, FontStyle.Bold);
                g.DrawImage(image, 0, 0);
                g.Dispose();

        }
        private List<Point> GetBaseData()
        {

            List<Point> result = new List<Point>();  //数据         
            DateTime UpM = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day).AddMonths(-1);//表示上个月第一天
            DateTime ToM = DateTime.Now.Date.AddDays(0 - DateTime.Now.Day);//表示上个月最后一天

            for (int i = 1; i < 7; i++)
            {
                string opensql;
                string a = "";
                a = UpM.ToString();

                DateTime d = Convert.ToDateTime(a);
                int month = d.Month;//存月份
                opensql = "select sum(用电度数) from 用电表  where  用电户号='" + "0000000000" + "' and 用电时间 between'" + UpM.ToString() + "'and  '" + ToM.ToString() + "'";

                int total;
                if (SQLDbHelper.ExecuteScalar(opensql,null) == DBNull.Value)//没有数据时
                {
                    total = 0;

                }
                else
                    total = Convert.ToInt32(SQLDbHelper.ExecuteScalar(opensql, null));
                Point p;
                p = new Point(month, total);//当前月份，用电总量

                result.Add(p);
                UpM = UpM.AddMonths(-1);//表示再上个月第一天
                ToM = ToM.AddMonths(-1);//表示再上个月最后一天
            }

            return result;

        }
        private void frmHistoryEletic_Paint(object sender, PaintEventArgs e)
        {
            graphEdit = new GraphEdit(480, 300, boardColor, 6, 7);//x代表X轴刻度线数量    //y代表Y轴刻度线数量   
            //横水平边距           
            //竖垂直边距            
            graphEdit.AreasColor = Color.FromArgb(50, 255, 128, 0);         //画图区域颜色
            graphEdit.AreasColor = Color.White;
            graphEdit.GraphColor = Color.FromArgb(255, 128, 0);        //曲线颜色  
            graphEdit.GraphColor = Color.Green;
            graphEdit.AxisColor = Color.FromArgb(155, 255, 212);         //坐标轴颜色            
            graphEdit.ScaleColor = Color.FromArgb(200, 145, 245, 245);          //刻度线颜色   
            graphEdit.ScaleColor = Color.Silver;
            Run();
        }

        private void frmHistoryEletic_Load(object sender, EventArgs e)
        {
            //LoadingUI();

        }

    }
}
