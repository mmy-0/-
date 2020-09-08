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
    public partial class frmSetnicheng : Form
    {
        public frmSetnicheng()
        {
            InitializeComponent();
        }

        private void btnCofirm_Click(object sender, EventArgs e)
        {
            string Sqlstr = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            string sqlText = "update 账号表 set 昵称=@昵称 where 登陆账号=@UserName";///////****************

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@昵称",txtNicheng.Text),
                new SqlParameter("@UserName",ParameterHelper.UserName)

            };

            SqlCommand sqlCmd = new SqlCommand(sqlText,conn);

            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);/////

            if (sqlCmd.ExecuteNonQuery() != 0)//////增加，删除，修改
                MessageBox.Show("chengong");

            conn.Close();
            ParameterHelper.Anonym = txtNicheng.Text;///////写入
            this.DialogResult = DialogResult.OK;
        }
        
    }
}
