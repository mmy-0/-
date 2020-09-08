using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;///////
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    public partial class frmLogRegister : Form
    {
        public frmLogRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册账号功能
        /// 伪代码算法：
        /// if()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResgister_Click(object sender, EventArgs e)
        {
            string s1 = txtAccount.Text;
            string s2 = txtPassword.Text;
            string s3 = txtId.Text;
            string s4 = txtSetPw.Text;

            if (s1==string.Empty || s2==string.Empty || s3==string.Empty)
            {
                MessageBox.Show("请输入完整信息");
                    
                txtAccount.Focus();
                return;
            }

            if(!string.Equals(s2,s4))
            {
                MessageBox.Show("两次密码不相同");
                txtSetPw.Focus();
                return;
            }
            //判定账号是否存在,三层架构
            string Sqlstr1 = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123"; //
            SqlConnection conn1 = new SqlConnection(Sqlstr1);
            conn1.Open();
            string sqlText1 = "select count(*) from 账号表 where 登陆账号=@usersName ";////
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",txtAccount.Text)
            };

            SqlCommand sqlCmd1 = new SqlCommand(sqlText1, conn1);
            if (p != null)
                sqlCmd1.Parameters.AddRange(p);

            int ii = Convert.ToInt32(sqlCmd1.ExecuteScalar());////////////////
            if (ii > 0)
            {
                MessageBox.Show("该用户存在，请输入其他账号");////////////
                return;//返回
            }
          
            //ADO.NET访问数据库一般方式（模式：简单，稳定，重复，结构性）
            string Sqlstr = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123";///
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
               
            //string sqlText = "insert into 账号表(登陆账号,密码,身份证号) values(7,7,7)";
            //string sqlText=string.Format("insert into 账号表(登陆账号,密码,身份证号) values('{0}','{1}','{2}')",s1,s2,s3);

            string sqlText = "insert into 账号表(登陆账号,密码,身份证号) values(@Account,@password,@id)";

            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@Account",txtAccount.Text),
                new SqlParameter("@password",txtPassword.Text),
                new SqlParameter("@id",txtId.Text)
            };
          
            SqlCommand sqlCmd = new SqlCommand(sqlText,conn);
            if (sp != null)
                sqlCmd.Parameters.AddRange(sp);

            int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果

            conn.Close();         

            if (i != 0)
                MessageBox.Show("chengong");

            
        }
        /// <summary>
        /// 登录功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string s1 = txtLogAccount.Text;
            string s2 = txtLogPass.Text;

            //判断s1,s1是否为空的处理

            //-------------------------------------------------------************-------------------
            string Sqlstr = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------

            string sqlText = "select count(*) from 账号表 where 登陆账号=@usersName and 密码=@usersPwd";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",txtLogAccount.Text),
                new SqlParameter("@usersPwd",txtLogPass.Text)
            };

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (p != null)
                sqlCmd.Parameters.AddRange(p);

            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());////////////////

            if (i>0)
            {
                MessageBox.Show("有此人");
                ParameterHelper.UserName = txtLogAccount.Text;/////////////////////“写入”登录账号“到传值
                conn.Close();
                this.DialogResult = DialogResult.OK;////////启动第二窗体frmMY
                this.Close();/////
            }
            else
                MessageBox.Show("密码或账号错");
        }
        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "server=LENOVO-PC;database=Palm_SC_Electric;uid=sa;pwd=123";//1:sqlserver
            //string constr = "server=.;database=Palm_SC_Electric;integrated security=SSPI";//2windows
            //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";//3:sql

            SqlConnection con = new SqlConnection();// SqlConnection con 1
            
            con.ConnectionString = constr;//2
            string sql = "select count(*) from 账号表";////////确定你要操作的数据表T-SQL:查，表名

            SqlCommand com = new SqlCommand(sql,con);///con关系com           

            try
            {
                con.Open();/////
                MessageBox.Show("成功连接数据库");

                int x = (int)com.ExecuteScalar();//////对执行SQL结果的一个处理过程
                MessageBox.Show(string.Format("成功读取{0},条记录", x));
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SQLDbHelper.GetConnettion().ToString());
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtLogPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtLogAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSetPw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVerificode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
