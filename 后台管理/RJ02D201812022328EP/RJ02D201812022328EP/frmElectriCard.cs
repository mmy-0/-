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
    public partial class frmElectriCard : Form
    {
        public frmElectriCard()
        {
            InitializeComponent();
        }
        public static bool wsgd;
        public static string ye = "";
        public void MyEleCardbd()
        {
            
            //显示登录用户他绑定的电卡
            string sqlText = "select *  from  记录表 t left join  电卡表 c  on t.用电户号 = c.用电户号 where t.登陆账号=@usersName  and t.是否绑定='true' ";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",ParameterHelper.UserName)//////读取
            };


            int a = 26;////////////
            SqlDataReader sdr = SQLDbHelper.ExecuteReader(sqlText, p);/////////调用封装好的类进行“查询”

            if (sdr.HasRows)
            {
                while (sdr.Read())
                {

                    wsgd = (bool)(sdr["网上购电"]);
                    ///控件构建
                    ucBDEC user = new ucBDEC();
                    user.Location = new Point(20, a);//////////计算控件放置的一个位置

                    user.Size = new Size(455, 241);/////

                    user.label7.Text = sdr["自定义卡名"].ToString();
                    user.label12.Text =sdr["用电户号"].ToString();
                    user.label13.Text = sdr["用户名称"].ToString();
                    user.label9.Text =sdr["余额"].ToString();
                    if (wsgd == true)
                    { 
                        user.label14.Text = "已开通"; 
                    }
                    else
                    {
                        user.label14.Text = "未开通";
                    }
                    this.panel1.Controls.Add(user);///////
                    //////////////////////////////////////////////////////////////////////////
                    user.label8.Text = "截止" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    a = a + 245;///////

                }
                sdr.Close();
            }
        }

        private void frmElectriCard_Load(object sender, EventArgs e)
        {
            MyEleCardbd();////////////
        }

        private void tianjiadianka_Click(object sender, EventArgs e)
        {

        }
    }
}
