using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    public partial class frmListView : Form
    {
        public frmListView()
        {
            InitializeComponent();
            
        }

        private void frmListView_Load(object sender, EventArgs e)
        {
            this.listView1.Columns.Add("用户账号", 120, HorizontalAlignment.Left); //一步添加 
            this.listView1.Columns.Add("卡号", 120, HorizontalAlignment.Left); 
            this.listView1.Columns.Add("住址", 120, HorizontalAlignment.Left);
            for (int i = 0; i < 6; i++)   //添加10行数据 
            {
                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标 
                lvi.Text = "item" + i;
                lvi.SubItems.Add("第2列,第" + i + "行");
                lvi.SubItems.Add("第3列,第" + i + "行");
                this.listView1.Items.Add(lvi);
            }

            lvTabInfo.Clear();
            lvTabInfo.View = View.Details;//**

            //列表头
            this.lvTabInfo.Columns.Add("栏目", 100, HorizontalAlignment.Center);
            this.lvTabInfo.Columns.Add("详细信息", 100, HorizontalAlignment.Center);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvTabInfo.Clear();
            lvTabInfo.View = View.Details;//**
            //列表头
            this.lvTabInfo.Columns.Add("栏目", 100, HorizontalAlignment.Center);
            this.lvTabInfo.Columns.Add("详细信息", 100, HorizontalAlignment.Center);
            foreach (ListViewItem lvi in listView1.SelectedItems)  //选中项遍历 
            {
                //MessageBox.Show(lvi.Index.ToString()); ///////////////////////////////////////      
                //MessageBox.Show(lvi.SubItems[0].Text);
                ShowTableInfoItem(lvTabInfo, "用户账号", lvi.SubItems[0].Text);
                //ShowTableInfoItem(lvTabInfo, "卡号", lvi.SubItems[1].Text);
                //ShowTableInfoItem(lvTabInfo, "住址", lvi.SubItems[2].Text);

            }   
        }

        /// <summary>
        /// 加载每个“项”的详细信息 - 按行加载
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="title"></param>
        /// <param name="info"></param>
        private void ShowTableInfoItem(ListView lv, string title, string info)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = title;
            lvi.ImageIndex = 0;
            lvi.SubItems.Add(info);
            lv.Items.Add(lvi);
        }
    }
}
