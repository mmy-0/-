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
using System.IO;

namespace Electricity
{
    public partial class MyPage : UserControl
    {
        private static MyPage myMainPage = new MyPage();
        private MyPage()
        {
            InitializeComponent();
        }

        public static MyPage getInstance()
        {
            return myMainPage;
        }

        private void button5_Click(object sender, EventArgs e)                  //设置
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(Setting.getInstance());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(Logon2.getInstance());
        }

        private void MyPage_Load(object sender, EventArgs e)
        {
            //if (Login.getInstance().Num() != null)
            //{
            //    this.label2.Text = Login.getInstance().Num();
            //}
            //else
            //    this.label2.Text = Register.getInstance().Account();
            ////从数据库中获取图片然后将图片绘制到picturebox中去

            //Graphics g = this.pictureBox1.CreateGraphics();

            ////SqlConnection conn = new SqlConnection(this.minechiefCertPaper);
            //string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            //SqlConnection conn = new SqlConnection(Sqlstr);
            //conn.Open();
            //string strSql = "SELECT * from Account1 where Login_ID='" + label2.Text + "'";
            //SqlCommand cmd = new SqlCommand(strSql, conn);
            //SqlDataReader reader = cmd.ExecuteReader();

            ////string strSql2 = "SELECT pet_name from Account1 where Login_ID='" + label2.Text + "'";
            ////SqlCommand cmd2 = new SqlCommand(strSql2, conn);
            ////SqlDataReader reader2 = cmd2.ExecuteReader();
            ////while (reader.Read()) //读取信息
            ////{

            ////}

            //reader.Read();
            //label1.Text = reader["pet_name"].ToString();
            ////创建一个内存   读取数据流，将读取的数据库的图片以二进制的byte[]流存入内存中。
            //MemoryStream ms = new MemoryStream((byte[])reader["head_sculpture"]);
            //reader.Close();
            ////reader2.Close();
            //conn.Close();
            ////Image zhaopian = Image.FromStream(ms, true);

            ////MemoryStream ms = new MemoryStream(imagebytes);
            //Bitmap bmpt = new Bitmap(ms);
            //pictureBox1.Image = bmpt;


            float d = 0;
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("select surplus from ELECRIC_CARD where user_account= '" + Login.getInstance().Card + "'", connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            d = Convert.ToInt32(reader[0]);
                        }
                    }
                }
            }

            if (d < 0)
            {
                MessageBox.Show("您已欠费！请尽快充值！");
            }






            ////0,0表示picturebox的顶点0，0，宽和高就是picturebox的宽和高
            //Rectangle rect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);
            ////这里绘制的是图片的内容区域，0,0表示从图片的顶点开始绘制起，zhoapian.width,zhaopian.height表示图片的宽度和高度，也就是绘制整张图片
            //Rectangle imageRect = new Rectangle(0, 0, zhaopian.Width, zhaopian.Height);

            //g.DrawImage(zhaopian, rect, imageRect, GraphicsUnit.Pixel);

            //byte[] imagebytes = null;
            //String imagebytes;
            //using (SqlConnection connection = new SqlConnection
            //            ("Server=.;Database=Chuandian_on_palm;Trusted_Connection=True"))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand("select head_sculpture from Account1 where Login_ID='" + label2.Text + "'", connection);
            //    using (SqlDataReader dr = command.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            imagebytes = (byte[])dr.GetValue(5);
            //            imagebytes = (String)dr.GetValue(1);
            //        }
            //        command.Clone();
            //    }
            //}
            //MemoryStream ms = new MemoryStream(imagebytes);
            //Bitmap bmpt = new Bitmap(ms);
            //pictureBox1.Image = bmpt;
        }
        public string Nam()
        {
            return label1.Text;
        }

        private void MyPage_Paint(object sender, PaintEventArgs e)
        {
            if (Login.getInstance().Num != null)
            {
                this.label2.Text = Login.getInstance().Num;
            }
            else
                this.label2.Text = Register.getInstance().Account();
            //从数据库中获取图片然后将图片绘制到picturebox中去

            Graphics g = this.pictureBox1.CreateGraphics();

            //SqlConnection conn = new SqlConnection(this.minechiefCertPaper);
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
            string strSql = "SELECT * from Account1 where Login_ID='" + label2.Text + "'";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            //string strSql2 = "SELECT pet_name from Account1 where Login_ID='" + label2.Text + "'";
            //SqlCommand cmd2 = new SqlCommand(strSql2, conn);
            //SqlDataReader reader2 = cmd2.ExecuteReader();
            //while (reader.Read()) //读取信息
            //{

            //}

            reader.Read();
            label1.Text = reader["pet_name"].ToString();
            //创建一个内存   读取数据流，将读取的数据库的图片以二进制的byte[]流存入内存中。
            MemoryStream ms = new MemoryStream((byte[])reader["head_sculpture"]);
            reader.Close();
            //reader2.Close();
            conn.Close();
            //Image zhaopian = Image.FromStream(ms, true);

            //MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bmpt = new Bitmap(ms);
            pictureBox1.Image = bmpt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog1.FileName;
                using (SqlConnection connection = new SqlConnection
                        ("Server=.;Database=Chuandian_on_palm;Trusted_Connection=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("update Account1 set head_sculpture=(select * from Openrowset(bulk '" + fullPath + "',single_blob) as a) where Login_ID = '" + label2.Text + "'", connection);
                    command.ExecuteNonQuery();
                   
                }
            }
            MessageBox.Show("修改成功！");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //我的电费
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(MyElectricity.getInstance());
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(ElectricityManage.getInstance());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(PayMin.getInstance());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Logon.getInstance().panel4.Controls.Clear();
            Logon.getInstance().panel4.Controls.Add(HistoryElectricity.getInstance());
            //MessageBox.Show(Logon.getInstance().panel4.Height.ToString());
            //MessageBox.Show(MyElectricity.getInstance().Height.ToString());

        }

        /// <summary>
        /// 显示和隐藏
        /// </summary>
        public bool flag = true;
        public bool flag2 = true;
        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                this.tableLayoutPanel2.Visible = true;
                flag = false;
                flag2 = true;
            }
            else
            {
                this.tableLayoutPanel2.Visible = false;
                flag = true;
                flag2 = true;
            }
        }

        /// <summary>
        /// 动态添加控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag2)
            {
                int i = 0;
                List<string> list = new List<string>();
                using (SqlConnection con = SQLManage.Connection())
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand("SELECT * FROM ELECRIC_CARD WHERE Login_ID = '" + Login.getInstance().Num + "'", con))
                    {
                        using (SqlDataReader reader = com.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i++;
                                list.Add(reader[0].ToString());
                            }
                        }
                    }
                }
                //MessageBox.Show(i.ToString());
                //table初始化
                tableLayoutPanel2.RowCount = i;
                MyTable.SetTableHeight(tableLayoutPanel2, i * 36);
                for (int j = 0; j < i; j++)
                {
                    tableLayoutPanel2.RowStyles[j].Height = 36;
                }
                

                //添加内容
                for (int j = 0; j < i; j++)
                {
                    Button bt = new Button();
                    bt.ForeColor = Color.White;
                    bt.Text = list[j];
                    //if (list[j] == Login.getInstance().Card)
                    //{
                    //    bt.BackColor = Color.Red;
                    //}
                    bt.Click += new EventHandler(ShowMessage);
                    bt.Height = 36;
                    bt.Width = tableLayoutPanel2.Width;
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.FlatAppearance.BorderSize = 0;
                    tableLayoutPanel2.Controls.Add(bt);
                }

                tableLayoutPanel2.Visible = true;
                //flag2 = false;
            }

        }

        //改变初始电卡
        private void ShowMessage(object sender, EventArgs e)
        {
            Login.getInstance().setBinding_card(((Button)sender).Text);
            this.tableLayoutPanel2.Visible = false;
            flag = true;        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


