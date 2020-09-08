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
    public partial class AllPage : UserControl
    {
        private static AllPage mainPage = new AllPage();
        private AllPage()
        {
            InitializeComponent();
        }

        public static AllPage getInstance()
        {
            return mainPage;
        }

        private void button6_Click(object sender, EventArgs e)          //生活服务
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(Service.getInstance());
        }

        private void button7_Click(object sender, EventArgs e)          //我的
        {
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(MyPage.getInstance());
        }

        private void button5_Click(object sender, EventArgs e)          //掌上川电
        {
            //MessageBox.Show(handCD.GetHashCode().ToString());
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(MainPage.getInstance());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.panel3.Controls.Add(MyPage.getInstance());
        }
    }
}
