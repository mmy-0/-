using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RJ02D201812022328EP
{
    public partial class ucBDEC : UserControl
    {
        public ucBDEC()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)//解除绑定
        {
            //第一步：构造与此功能相关的SQL语句
            string sqlText = "Update 记录表 set 是否绑定='false'  where 登陆账号= @x and 用电户号= @y";
            //第二步：（sql若是带参数的语句，则添加参数数组，若无，省略下面参数）
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@x",ParameterHelper.UserName),
                new SqlParameter("@y",label12.Text)
            };
            //第三步，调用SQLDbHelper中的方法
            //若，增删改，调用ExecuteNonQuery  ，后续处理或显示增删改的结果（成功或失败）
            //若，查，    调用ExecuteReader    ，后续借助控件显示查询的结果
            //若，统计，  调用ExecuteScalar    ，后续处理或显示统计的结果

            int i=SQLDbHelper.ExecuteNonQuery(sqlText, p);
            if (i>0)
            {
                MessageBox.Show("OKLLLLA");
            }
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)///设置默认卡
        {

            //第一步：构造与此功能相关的SQL语句
            string sqlText = "Update 记录表 set 选中 = 'false' where 登陆账号 = @x and 选中 = 'true';";
            sqlText = sqlText + "Update 记录表 set 选中 = 'true' where 登陆账号 = @x and 用电户号 = @y";
            //第二步：（sql若是带参数的语句，则添加参数数组，若无，省略下面参数）
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@x",ParameterHelper.UserName),
                new SqlParameter("@y",label12.Text)
            };
            //第三步，调用SQLDbHelper中的方法
            //若，增删改，调用ExecuteNonQuery  ，后续处理或显示增删改的结果（成功或失败）
            //若，查，    调用ExecuteReader    ，后续借助控件显示查询的结果
            //若，统计，  调用ExecuteScalar    ，后续处理或显示统计的结果

            int i = SQLDbHelper.ExecuteNonQuery(sqlText, p);
            if (i > 0)
            {
                MessageBox.Show("OKLLQQQQQQQQLLA");
            }

        }
    }
}
