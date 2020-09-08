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

namespace Demo20191211
{
    public partial class frmLogRegister : Form
    {
        public frmLogRegister()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnResgister_Click(object sender, EventArgs e)///注册功能
        {
            //第一步：构造与此功能相关的SQL语句



            string sqlText = "insert into 账号表(登陆账号,密码,身份证号) values(@Account,@password,@id)";
            //第二步：（sql若是带参数的语句，则添加参数数组，若无，省略下面参数）
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Account",txtAccount.Text),
                new SqlParameter("@password",txtPassword.Text),
                new SqlParameter("@id",txtId.Text)
            };
            //第三步，调用SQLDbHelper中的方法
            int i=SQLDbHelper.ExecuteNonQuery(sqlText,sp);
            //若，增删改，调用ExecuteNonQuery  ，后续处理或显示增删改的结果（成功或失败）
            if (i>0)
            {
                MessageBox.Show("Ok");
            }
            //若，查，    调用ExecuteReader    ，后续借助控件显示查询的结果
            //若，统计，  调用ExecuteScalar    ，后续处理或显示统计的结果
            
        }
    }
}
