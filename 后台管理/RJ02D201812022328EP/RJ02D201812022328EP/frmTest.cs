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
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            string Sqlstr = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
            string strSql = "select 用电户号,登陆账号,用户名称,网上购电,自定义卡名,余额 from 电卡表"; 
            SqlDataAdapter da = new SqlDataAdapter(strSql,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            
        }
    }
}
