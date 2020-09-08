using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    public partial class frmPurchaseElectricityDetail : Form
    {
        public frmPurchaseElectricityDetail()
        {
            InitializeComponent();
        }

        private void frmPurchaseElectricityDetail_Load(object sender, EventArgs e)
        {

            /////////显示某电卡用户充值金额
            string sqlText = "select * from 缴费表 where 用电户号=@usersName ";////

            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName","0000000000")
            };           
            try
            {
                SqlDataReader sdr = SQLDbHelper.ExecuteReader(sqlText, p);//////////   ***********************************             
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ListViewItem lvi = new ListViewItem();/////////
                        lvi.Text = sdr["缴费时间"].ToString();
                        lvi.SubItems.Add(sdr["充值费"].ToString());
                        lvi.ImageIndex = 1;
                        lvjiaofeimx.Items.Add(lvi);/////////////////
                    }
                    sdr.Close();

                }
            }
            catch
            { }

            /////////计算总充值费
            string sqlSumtText = "select sum(充值费)  from  缴费表";

            label10.Text = SQLDbHelper.ExecuteScalar(sqlSumtText,null).ToString();          

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            pictureBox3.Region = region;
            gp.Dispose();
            region.Dispose();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox2.ClientRectangle);
            Region region = new Region(gp);
            pictureBox2.Region = region;
            pictureBox4.Region = region;
            gp.Dispose();
            region.Dispose();
        }
    }
}
