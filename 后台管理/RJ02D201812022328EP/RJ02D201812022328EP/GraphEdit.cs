using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    public class GraphEdit
    {
        public GraphEdit(int width, int height, Color boradColor,int x,int y)//默认值  
        {
            this.BoardWidth = width;
            this.BoardHeight = height;
            this.BoardColor = boradColor;                       
            this.XScaleCount = x;
            this.YScaleCount = y;
            this.HorizontalMargin = 5;//默认左右外边距为5
            this.VerticalMargin = 25;//默认上下外边距为25
            this.AxisColor = Color.Black;//表示坐标字体颜色
        }
        #region 基础设置

        /// <summary>        
        /// 当前绘制的图       
        /// 
        /// </summary>        
        public Bitmap CurrentImage { get; set; }

        /// <summary>       
        /// 画板宽度       
        /// </summary>        
        public int BoardWidth { get; set; }

        /// <summary>       
        ///  画板高度        
        /// </summary>        
        public int BoardHeight { get; set; }

        /// <summary>        
        /// 画板背景颜色        
        /// </summary>        
        public Color BoardColor { get; set; }

        /// <summary>       
        /// 
        /// 画图区域颜色        
        /// </summary>        
        public Color AreasColor { get; set; }

        /// <summary>       
        ///  曲线图颜色        
        /// </summary>        
        public Color GraphColor { get; set; }

        /// <summary>       
        ///  坐标轴颜色        
        /// </summary>        
        public Color AxisColor { get; set; }

        ///  <summary>        
        /// 刻度线颜色       
        ///  </summary>       
        public Color ScaleColor { get; set; }

        /// <summary>        
        /// 垂直（纵向）边距（画图区域距离上下两边长度）        
        /// </summary>        
        public int VerticalMargin { get; set; }

        /// <summary>        
        /// 平行（横向）边距（画图区域距离左右两边长度）       
        /// 
        /// </summary>        
        public int HorizontalMargin { get; set; }

        /// <summary>       
        /// 
        /// X轴刻度线数量        
        /// </summary>        
        public int XScaleCount { get; set; }

        /// <summary>        
        /// Y轴刻度线数量        
        /// </summary>        
        public int YScaleCount { get; set; }

        #endregion
        /// <summary>       
        /// 
        /// 获得当前数据画出的曲线面积图       
        /// 
        /// </summary>        
        /// <param name="data">需要绘制的数据</param>        
        /// <param name="xRange">X轴范围（data数据里面的实际范围）</param>       
        /// <param name="yRange">Y轴范围（data数据里面的实际范围）</param>       
        /// <param name="isFill">是否需要面积填充</param>        
        /// <returns>当前的曲线面积图</returns>  
       
         public Image GetCurrentGraph(List<Point> data)
        {

            CurrentImage = new Bitmap(BoardWidth, BoardHeight);//画板大小为输入大小
            Graphics g = Graphics.FromImage(CurrentImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;   //反锯齿           
            g.Clear(BoardColor);
            //1.确定曲线图区域    
            int iAreaWidth = BoardWidth - 2 * HorizontalMargin;             //画图区域宽度            
            int iAreaHeight = BoardHeight - 2 * VerticalMargin;             //画图区域高度            
            Point pAreaStart = new Point(HorizontalMargin, VerticalMargin);  //画图区域起点           
            Point pAreaEnd = new Point(BoardWidth - HorizontalMargin, BoardHeight - VerticalMargin);      //画图区域终点            
            Point pOrigin = new Point(HorizontalMargin, BoardHeight - VerticalMargin);  //原点           
            Rectangle rectArea = new Rectangle(pAreaStart, new Size(iAreaWidth, iAreaHeight));
            SolidBrush sbAreaBG = new SolidBrush(AreasColor);
            g.FillRectangle(sbAreaBG, rectArea);
            sbAreaBG.Dispose();

            //3.确定刻度线和标签           
            Pen penScale = new Pen(ScaleColor, 1);//刻度线笔
            penScale.DashStyle = DashStyle.Custom;//画虚线
            penScale.DashStyle = DashStyle.Solid;
            //penScale.DashPattern = new float[] { 3, 3 };
            int fontSize = 10;//标签大小
            List<Point> listPointData = SortingData(data);             
            //4.3.数据转换：将实际的数据转换到图上的点    数据排序 ：为了能顺序画出图，需要对X轴上的数据进行排序  冒泡排序
            for (int i = 0; i < 6; i++)
            {
                string lbl = listPointData[i].X.ToString() + "月";
                int x = i * (iAreaWidth / XScaleCount) + pAreaStart.X + 30;//乘以i是 固定标签之间(刻度线间)间距
                g.DrawString(lbl, new Font("微软雅黑", fontSize, FontStyle.Regular), new SolidBrush(AxisColor), new Point(x - fontSize, pAreaEnd.Y + VerticalMargin / 9));
            }
            for (int i = 0; i <= YScaleCount; i++)
            {
                int y = pAreaEnd.Y - (i * (iAreaHeight / YScaleCount));
                g.DrawLine(penScale, pAreaStart.X, y, pAreaEnd.X, y);
            }
            // 4.画曲线面积            //4.1得到数据                         
            List<Point> listPointGraphics = new List<Point>();//4.2 图上的点    
            Pen penDian = new Pen(Color.FromArgb(255, 128, 0), 3);//刻度线笔
            for (int j = 0; j < listPointData.Count; j++)
            {
                Point p = new Point();
                p.X = j * (iAreaWidth / XScaleCount) + pAreaStart.X + 30;
                p.Y = pOrigin.Y - listPointData[j].Y;
                g.DrawEllipse(penDian, p.X - 4, p.Y - 1, 3, 3);//点的位置
                g.DrawString(listPointData[j].Y.ToString(), new Font("微软雅黑", fontSize, FontStyle.Regular), new SolidBrush(Color.FromArgb(255,128,0)), new Point(p.X - 15, p.Y - 15));
                listPointGraphics.Add(p);
            }
            Point[] myArray ={
                               listPointGraphics[0],//6月
                               listPointGraphics[1],
                               listPointGraphics[2],
                               listPointGraphics[3],
                               listPointGraphics[4],//10月
                               listPointGraphics[5]
                          };

                //4.3将点的集合加入到画曲线图的路径中            
                GraphicsPath gpArea = new GraphicsPath();             //第一个点  //起点要从X轴上开始画 结束点也要画回X轴：即在开始点和结束点要多画一次原点的Y           
                gpArea.AddLine(new Point(listPointGraphics[0].X, pOrigin.Y), listPointGraphics[0]);
                gpArea.AddCurve(myArray);//中间点
                gpArea.AddLine(listPointGraphics[listPointGraphics.Count - 1], new Point(listPointGraphics[listPointGraphics.Count - 1].X, pOrigin.Y)); //最后一个点     
                 g.DrawCurve(new Pen(GraphColor, 2), myArray,0.4f);//画曲线

                SolidBrush brush = new SolidBrush(Color.FromArgb(50, 255, 192, 0));//定义单色画刷   
                g.FillPath(brush, gpArea);   //填充            
                gpArea.CloseFigure();  //是否封闭  
                return CurrentImage;
            }

        /// <summary>        
        /// 数据排序       
        /// </summary>        
        /// <param name="lp"></param>        
        /// <returns></returns>       
        private List<Point> SortingData(List<Point> lp)
        {
            List<Point> a = new List<Point>();
            int i = lp.Count - 1;
            while (i >= 0)
            {
                a.Add(lp[i]);
                i--;
            }

            return a;

        }

    }
}
