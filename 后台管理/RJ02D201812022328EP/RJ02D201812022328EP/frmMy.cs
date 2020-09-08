using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJ02D201812022328EP
{
    /// <summary>
    /// 主窗体通过模式对话框调用和显示其它各个窗体
    /// 
    /// </summary>
    public partial class frmMy : Form
    {
        public frmMy()
        {
            InitializeComponent();
        }/////1
        private byte[] picData = null;
        private string txtFilePath = "";
        private void frmMy_Load(object sender, EventArgs e)///2
        {

            txtMyAccount.Text = "欢迎" + ParameterHelper.UserName;////////////读取账号信息
            //第一步：构造与此功能相关的SQL语句
            string sqlText = "select * from 账号表 where 登陆账号=@x";

            //第二步：（sql若是带参数的语句，则添加参数数组，若无，省略下面参数）
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@x",ParameterHelper.UserName)/////读取ParameterHelper.UserName
               
            };
            SqlDataReader sdr = SQLDbHelper.ExecuteReader(sqlText,p);//////////   ***********************************       
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    if (sdr["头像"] == DBNull.Value)
                    {
                        picHeadImag.Image = Properties.Resources.我的;/////
                    }
                    else
                    {
                        byte[] b = (byte[])(sdr["头像"]);//
                        picHeadImag.Image = Image.FromStream(new MemoryStream(b));////////                        
                    }

                    if (sdr["昵称"].ToString() == null)
                    {
                        txtMyAccount.Text = ParameterHelper.UserName;//只显示账号
                    }
                    else
                    {
                        txtName.Text = sdr["昵称"].ToString();
                        txtMyAccount.Text = ParameterHelper.UserName;                        
                    }

                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSet f = new frmSet();///////
            
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                txtName.Text = ParameterHelper.Anonym;///////
                MessageBox.Show("ok");
            }

            //ParameterHelper.UserName
           
        }


        /// <summary>
        /// 更新增加头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picHeadImag_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picHeadImag.Image = Image.FromFile(openFileDialog1.FileName);///
                string txtFilePath = openFileDialog1.FileName;
                byte[] b = null;
                if (txtFilePath != "")
                {
                    try
                    {
                        FileStream fs = new FileStream(txtFilePath, FileMode.Open, FileAccess.Read);//是数据库里面如果有图片就读出来
                        int len = Convert.ToInt32(fs.Length);
                        b = new byte[len];
                        fs.Read(b, 0, len);
                        fs.Close();
                    }
                    catch
                    {
                        b = null;
                    }
                }
                else
                {
                    b = picData;
                }

                try//换头像存头像
                {
                    string Sqlstr = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123";
                    SqlConnection conn = new SqlConnection(Sqlstr);
                    conn.Open();
                    string sqlText = "update 账号表 set 头像=@头像 where 登陆账号= @Account";
                    SqlParameter[] sp = new SqlParameter[]
                    {
                        new SqlParameter("@头像",b),
                        new SqlParameter("@Account",ParameterHelper.UserName)
                        
                    };
                    SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
                    if (sp != null)
                        sqlCmd.Parameters.AddRange(sp);
                    int i = sqlCmd.ExecuteNonQuery();//准备处理增删改查（T-SQL）操作的结果
                    conn.Close();
                    MessageBox.Show("更新成功");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmElectriCard f = new frmElectriCard();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                txtName.Text = ParameterHelper.Anonym;
                MessageBox.Show("ok");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmPurchaseElectricityDetail f = new frmPurchaseElectricityDetail();
            if (f.ShowDialog(this) == DialogResult.OK)
            {                
                MessageBox.Show("ok");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmHistoryEletic f = new frmHistoryEletic();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show("ok");
            }
        }


    }
}
