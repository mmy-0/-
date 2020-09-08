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

namespace _666
{
    public partial class frmAllUser : Form
    {
        public frmAllUser()
        {
            InitializeComponent();
        }

        private void frmAllUser_Load(object sender, EventArgs e)
        {
            lvContact.Clear();
            lvContact.Columns.Add("用电户号", 100);
            lvContact.Columns.Add("登陆账号", 150);
            lvContact.Columns.Add("用户名称", 100);
            lvContact.Columns.Add("网上购电", 100);
            lvContact.Columns.Add("自定义卡名", 150);
            lvContact.Columns.Add("余额", 100);

            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
            string sqlText = "select  * from Account1,ELECRIC_CARD where Account1.Login_ID = ELECRIC_CARD.Login_Id";
            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);

            /////////////---------------------------------------------------------////////////////////////
            try
            {
                SqlDataReader sdr = sqlCmd.ExecuteReader();
                int count = 0;
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = sdr["binding_card"].ToString();
                        lvi.SubItems.Add(sdr["Login_ID"].ToString());
                        lvi.SubItems.Add(sdr["pet_name"].ToString());
                        lvi.SubItems.Add(sdr["nickname"].ToString());
                        lvi.SubItems.Add(sdr["surplus"].ToString());
                        lvi.ImageIndex = 0;
                        lvContact.Items.Add(lvi);
                        count++;
                    }
                }

                tsslCount.Text = "共计" + count.ToString() + "个电卡";
                sdr.Close();
                conn.Close();
            }
            catch
            { }

        }

        private void 详细信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lvContact.View = View.Details;
        }
    }
}
