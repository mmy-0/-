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

namespace 后台管理
{
    public partial class 首页 : UserControl
    {

        private static 首页 nanegement = new 首页();

        public static 首页 getInstance()
        {
            return nanegement;
        }
        public 首页()
        {
            InitializeComponent();
        }

        private void 售电统计_Load(object sender, EventArgs e)
        {
            //select count(*) from Account1
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("select count(*) from Account1", connection))
                {
                    using (SqlDataReader reader1 = com.ExecuteReader())
                    {
                        reader1.Read();
                        //MessageBox.Show(reader1[0].ToString());
                        this.label2.Text = "一共" + reader1[0].ToString() + "个用户";                     
                    }
                }
            }
            //string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            //SqlConnection conn = new SqlConnection(Sqlstr);
            //conn.Open();
            //string strSql = "select  Account1.Login_ID,ID_Number,pet_name,binding_address,binding_card,surplus,nickname,Online_opening from Account1,ELECRIC_CARD where Account1.Login_ID = ELECRIC_CARD.Login_Id";
            //SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
            MyDataGridBiew.IsControl(dataGridView1,false, false);
            int [] width= { 500};
            MyDataGridBiew.SetWidth(dataGridView1,width);

            MyDataGridBiew.DataConnection(dataGridView1,"select  Account1.Login_ID, ID_Number, pet_name, binding_address, binding_card, surplus, nickname, Online_opening from Account1, ELECRIC_CARD where Account1.Login_ID = ELECRIC_CARD.Login_Id");

            MyDataGridBiew.Format(dataGridView1, false, true, Color.White, Color.Red,Color.White,Color.Black);
        }
    }
}
