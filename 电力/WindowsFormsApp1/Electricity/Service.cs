using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electricity
{
    public partial class Service : UserControl
    {
        private static Service lifeService = new Service();
        private List<Image> lst = new List<Image>();//储存图片集合
        private int ImageIndex = 0;//用于计时器自增计数
        public Service()
        {
            InitializeComponent();
            Picture();//插入图片
            timer1.Interval = 2000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Enabled = true;
        }

        public static Service getInstance()
        {
            return lifeService;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("你已在生活服务");
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(Electricityapp2.getInstance());
        }

        private void timer1_Tick(object sender, EventArgs e)//显示图片每2秒切换
        {
            pictureBox1.Image = lst[ImageIndex];
           // pictureBox1.Image.Width = 495;
            //Thread.Sleep(2000);
            ImageIndex++;
            if (ImageIndex > lst.Count - 1) ImageIndex = 0;//当ImageIndex 大于集合的长度初始他在重新遍历集合
        }
        public void Picture()//把文件夹中的图片全部加入集合
        {
            lst.Add(Properties.Resources.图1_1);
            lst.Add(Properties.Resources.图2_2);
            lst.Add(Properties.Resources.图3_3);
            pictureBox1.Image = lst[ImageIndex];
        }
    }
}
