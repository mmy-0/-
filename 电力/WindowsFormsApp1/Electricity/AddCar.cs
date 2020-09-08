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

namespace Electricity
{
    public partial class AddCar : UserControl
    {
        private static AddCar Addcar = new AddCar();
        public static AddCar getInstance()
        {
            return Addcar;
        }
        public AddCar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s1 = txtAccount.Text;
            string s2 = txtuser.Text;
            string s3 = nickname.Text;
            string adrss = "德阳电力有限公司";
            if (s1 == string.Empty || s2 == string.Empty || s3 == string.Empty)
            {
                MessageBox.Show("请输入完整信息");
                txtAccount.Focus();
                return;
            }
            int d = Electricityapp2.getInstance().Pan("select *from ELECRIC_CARD where user_account='" + txtuser.Text + "'");
            if (d < 1)
            {
                using (SqlConnection connection2 = SQLManage.Connection())
                {
                    connection2.Open();
                    SqlCommand com2 = new SqlCommand(" insert ELECRIC_CARD(user_account, binding_address, Login_ID, surplus, Days_Remaining, Online_opening, nickname)values('" + txtuser.Text + "', '" + adrss + "', '" + txtAccount.Text + "', '0', '0', 1,'" + nickname.Text + "')", connection2);
                    com2.ExecuteNonQuery();
                }
                MessageBox.Show("绑定成功！");
            }
            else
            {
                MessageBox.Show("此卡已经有人添加");
                txtuser.Focus();
                return;
            }

            ////---------------------------------------------------------------------------------////
            ////ADO.NET访问数据库一般方式（模式：简单，稳定，重复，结构性）
            //string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            //SqlConnection conn = new SqlConnection(Sqlstr);
            //conn.Open();
            ////---------------------------------------------------------------------------------////          
            ////string sqlText = "insert into 账号表(登陆账号,密码,身份证号) values(7,7,7)";
            ////string sqlText=string.Format("insert into 账号表(登陆账号,密码,身份证号) values('{0}','{1}','{2}')",s1,s2,s3);


            //string sqlText = " insert ELECRIC_CARD(user_account, binding_address, Login_ID, surplus, Days_Remaining, Online_opening, nickname)values(@Account, '" + adrss + "', @user, '0', '0', 1, @nickname)";
            //SqlParameter[] sp = new SqlParameter[]
            //{
            //    new SqlParameter("@Account",txtAccount.Text),
            //    new SqlParameter("@user",txtuser.Text),
            //     new SqlParameter("@nickname",nickname.Text),

            //};
            ////---------------------------------------------------------------------------------////
            //SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            //if (sp != null)
            //    sqlCmd.Parameters.AddRange(sp);

            //int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果

            //conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(ElectricityManage.getInstance());
        }
    }
}
