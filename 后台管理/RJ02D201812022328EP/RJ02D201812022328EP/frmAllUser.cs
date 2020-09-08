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
    public partial class frmAllUser : Form
    {
        public frmAllUser()
        {
            InitializeComponent();
        }

        private void frmAllUser_Load(object sender, EventArgs e)
        {
            //lvContact.Columns.Add()
            string Sqlstr = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
            string sqlText = "select 用电户号,登陆账号,用户名称,网上购电,自定义卡名,余额 from 电卡表";////////
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
          
            try
            {
                SqlDataReader sdr = sqlCmd.ExecuteReader();//////////   ***********************************             
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        //MessageBox.Show("当前获取的是"+sdr["用电户号"].ToString()+"---"+sdr[1].ToString()+"---"+sdr.GetDecimal(5));
                        ListViewItem lvi = new ListViewItem();
                        
                        lvi.Text = sdr["用电户号"].ToString();
                        lvi.SubItems.Add(sdr["登陆账号"].ToString());
                        lvi.SubItems.Add(sdr["用户名称"].ToString());
                        lvi.SubItems.Add(sdr["网上购电"].ToString());
                        lvi.SubItems.Add(sdr["自定义卡名"].ToString());
                        lvi.SubItems.Add(sdr["余额"].ToString());
                        if (float.Parse(sdr["余额"].ToString()) >= 50)
                        {
                            lvi.ImageIndex = 1;
                        }
                        else
                        {
                            lvi.ImageIndex = 0;
                        }

                        lvContact.Items.Add(lvi);                       
                    }                  
                    sdr.Close();
                    conn.Close();
                }
            }
            catch
            { }
            
        }

        private void 详细信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lvContact.View = View.Details;
        }

        private void 图标ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lvContact.View = View.SmallIcon;
        }

        private void 大图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvContact.View = View.LargeIcon;
        }

        private void tsbtnView_Click(object sender, EventArgs e)
        {

        }
    }
}
