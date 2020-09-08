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
    public partial class frmzc : Form
    {
        public frmzc()
        {
            InitializeComponent();
        }

        private void btnResgister_Click(object sender, EventArgs e)
        {
            string sqlText = "insert into 账号表(登陆账号,密码,身份证号) values(@Account,@password,@id)";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Account",txtAccount.Text),
                new SqlParameter("@password",txtPassword.Text),
                new SqlParameter("@id",txtId.Text)
            };
            int i =SQLDbHelper.ExecuteNonQuery(sqlText, sp);
            if (i>0)
            {
                MessageBox.Show("okk");
            }

            

        }
    }
}
