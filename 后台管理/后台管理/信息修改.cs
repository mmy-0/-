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

namespace 后台管理
{
    public partial class 信息修改 : UserControl
    {
        private static 信息修改 inquiry = new 信息修改();

        public static 信息修改 getInstance()
        {
            return inquiry;
        }
        public 信息修改()
        {
            InitializeComponent();
        }
        private string option = "";
        private string Login = "";
        List<string> b = new List<string>();
        private void 信息修改_Load(object sender, EventArgs e)
        {

            //Dictionary<string, List<string>> d = new Dictionary<string, List<string>>();
            //d = MySqlManage.GetQuery("SELECT * FROM Account1", 5);
            //foreach (string key in d.Keys)
            //{
            //    comboBox1.Items.Add(key);
            //}
            Ready();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fullPath = openFileDialog1.FileName;
                using (SqlConnection connection = new SqlConnection("Server=.;Database=Chuandian_on_palm;Trusted_Connection=True"))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("update Account1 set head_sculpture=(select * from Openrowset(bulk '" + fullPath + "',single_blob) as a) where binding_card = '" + textBox6.Text + "'", connection);
                    command.ExecuteNonQuery();

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            option = "";

            for (int i = 0; i < this.comboBox1.Items.Count; i++)
            {
                if (comboBox1.SelectedItem == comboBox1.Items[i])
                {
                    option = comboBox1.SelectedItem.ToString();
                }
            }
            Picture();
            LoginID();
        }
        private void Picture()
        {
            int a=0;

            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("SELECT * from Account1 where binding_card = '" + option + "' ", connection))
                {
                    using (SqlDataReader reader1 = com.ExecuteReader())
                    {
                        reader1.Read();
                        textBox1.Text = reader1["pet_name"].ToString();
                        textBox3.Text = reader1["binding_card"].ToString();
                    }
                }
            }

            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("SELECT * FROM ELECRIC_CARD where user_account = '" + option + "'", connection))
                {
                    using (SqlDataReader reader1 = com.ExecuteReader())
                    {
                        reader1.Read();
                        textBox2.Text = reader1["nickname"].ToString();
                        textBox4.Text = reader1["binding_address"].ToString();
                        textBox5.Text = reader1["surplus"].ToString();
                    }
                }
            }
           

            int d = 0;
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("select Online_opening from ELECRIC_CARD where user_account = '" + option + "'", connection))
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
            if (d == 1)
            {
                label8.Text = "正常";
                this.label8.ForeColor = Color.Green;
            }
            if (d == 0)
            {
                label8.Text = "已注销";
                this.label8.ForeColor = Color.Red;
            }

            a = Convert.ToInt32(textBox5.Text);
            if (d==1&&a < -50)
            {
                MessageBox.Show("此用户已严重欠费，请注销！");
            }
        }

        //账号赋值
        private void LoginID()
        {
            Login = "";
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("select *from Account1 where binding_card='" + option + "'", connection))
                {
                    using (SqlDataReader reader1 = com.ExecuteReader())
                    {
                        reader1.Read();
                        Login = reader1["Login_ID"].ToString();
                    }
                }
            }
        }
        //图片
        private void button6_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------


            string sqlText = "select count(*) from Account1 where binding_card=@usersName";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",textBox6.Text)
            };

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (p != null)
                sqlCmd.Parameters.AddRange(p);
            //MessageBox.Show(sqlCmd.ExecuteScalar().ToString());
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (i > 0)
            {
                Graphics g = this.pictureBox1.CreateGraphics();
                string Sqlstr2 = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
                SqlConnection conn2 = new SqlConnection(Sqlstr2);
                conn2.Open();
                string strSql2 = "SELECT * from Account1 where binding_card = '" + textBox6.Text + "' ";
                SqlCommand cmd = new SqlCommand(strSql2, conn2);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                //创建一个内存   读取数据流，将读取的数据库的图片以二进制的byte[]流存入内存中。
                MemoryStream ms = new MemoryStream((byte[])reader["head_sculpture"]);

                textBox1.Text = reader["pet_name"].ToString();
                textBox3.Text = reader["binding_card"].ToString();
                reader.Close();
                conn.Close();
                Bitmap bmpt = new Bitmap(ms);
                pictureBox1.Image = bmpt;
            }
            else
                MessageBox.Show("请输入默认电卡");
        }

        //账号昵称
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                string sql = "UPDATE Account1 SET pet_name = '" + textBox1.Text + "' where binding_card = '" + option + "'";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("昵称修改成功！");
            }
        }

        //电卡昵称
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                string sql = "UPDATE ELECRIC_CARD SET nickname = '" + textBox2.Text + "' where user_account = '" + option + "'";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("昵称修改成功！");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------------************-------------------
            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();

            //-------------------------------------------------------************-------------------


            string sqlText = "select count(*)from ELECRIC_CARD where Login_Id= '" + Login + "'  and user_account=@usersName";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@usersName",textBox3.Text)
            };

            SqlCommand sqlCmd = new SqlCommand(sqlText, conn);
            if (p != null)
                sqlCmd.Parameters.AddRange(p);
            //MessageBox.Show(sqlCmd.ExecuteScalar().ToString());
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());

            if (i > 0)
            {
                using (SqlConnection con = SQLManage.Connection())
                {
                    con.Open();
                    string sql = "UPDATE Account1 SET binding_card = '" + textBox3.Text + "' where binding_card = '" + option + "'";
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.ExecuteNonQuery();
                    }
                    MessageBox.Show("修改成功！");
                }
            }
            else
                MessageBox.Show("请输入已有的默认电卡");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                string sql = "UPDATE ELECRIC_CARD SET binding_address = '" + textBox4.Text + "' where user_account = '" + option + "'";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("地址修改成功！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = SQLManage.Connection())
            {
                con.Open();
                string sql = "UPDATE ELECRIC_CARD SET surplus = '" + textBox5.Text + "' where user_account = '" + option + "'";
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
                MessageBox.Show("余额修改成功！");
            }
        }

        private void 信息修改_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ready();
        }
        private void Ready()
        {
            comboBox1.Items.Clear();

            b = MySqlManage.GetContent("SELECT * FROM Account1", 5);
            foreach (string key in b)
            {
                comboBox1.Items.Add(key);
            }

            Graphics g = this.pictureBox1.CreateGraphics();

            string Sqlstr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            SqlConnection conn = new SqlConnection(Sqlstr);
            conn.Open();
            string strSql = "SELECT * from Account1";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            //创建一个内存   读取数据流，将读取的数据库的图片以二进制的byte[]流存入内存中。
            MemoryStream ms = new MemoryStream((byte[])reader["head_sculpture"]);

            textBox1.Text = reader["pet_name"].ToString();
            textBox3.Text = reader["binding_card"].ToString();
            textBox6.Text = reader["binding_card"].ToString();
            Login = reader["Login_ID"].ToString();
            reader.Close();
            //reader2.Close();
            conn.Close();
            //Image zhaopian = Image.FromStream(ms, true);

            //MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bmpt = new Bitmap(ms);
            pictureBox1.Image = bmpt;

            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("SELECT * FROM ELECRIC_CARD", connection))
                {
                    using (SqlDataReader reader1 = com.ExecuteReader())
                    {
                        reader1.Read();
                        textBox2.Text = reader1["nickname"].ToString();
                        textBox4.Text = reader1["binding_address"].ToString();
                        textBox5.Text = reader1["surplus"].ToString();
                        //reader1.Close();
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int d=0;
            using (SqlConnection connection = SQLManage.Connection())
            {
                connection.Open();
                using (SqlCommand com = new SqlCommand("select Online_opening from ELECRIC_CARD where user_account = '" + option + "'", connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            d =Convert.ToInt32( reader[0]);
                        }
                    }
                }
            }
            //string a = d.ToString();
            //MessageBox.Show(a);
            if (d == 1)
            {
                using (SqlConnection con = SQLManage.Connection())
                {
                    con.Open();
                    string sql = "UPDATE ELECRIC_CARD SET Online_opening = '0' where user_account = '" + option + "'";
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.ExecuteNonQuery();
                    }
                    MessageBox.Show("注销成功");
                }
            }
            if (d == 0)
            {
                using (SqlConnection con = SQLManage.Connection())
                {
                    con.Open();
                    string sql = "UPDATE ELECRIC_CARD SET Online_opening = '1' where user_account = '" + option + "'";
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.ExecuteNonQuery();
                    }
                    MessageBox.Show("激活成功");
                }
            }

        }
    }
}


