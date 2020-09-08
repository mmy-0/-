using System;

namespace ConsoleApp1
{
 class Program
    {
        static void Main()
        {

            Console.WriteLine(DateTime.Now.ToString());
        }
       
        //static void Main(string[] args)
        //{
        //    MyClass1 m1 = MyClass1.getInstance();
        //    MyClass1 m2 = MyClass1.getInstance();
        //    MyClass2 m11 = MyClass2.getInstance();
        //    MyClass2 m12 = MyClass2.getInstance();
        //    Console.WriteLine(m1.Equals(m2));
        //    Console.WriteLine(m11.Equals(m12));

        //}
    }
    class MyClass1
    {
        private string msg = "asd";
        private static MyClass1 m1 = new MyClass1();

        public string getMsg()
        {
            return msg;
        }

        public static MyClass1 getInstance()
        {
            return m1;
        }
    }
    class MyClass2
    {
        private static MyClass2 m2 = new MyClass2();

        public static MyClass2 getInstance()
        {
            return m2;
        }
    }
}

//private void button1_Click(object sender, EventArgs e)
//{
//    openFileDialog1.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
//    if (openFileDialog1.ShowDialog() == DialogResult.OK)
//    {
//        string fullPath = openFileDialog1.FileName;
//        using (FileStream fs = new FileStream(fullPath, FileMode.Open))
//        {
//            byte[] imagebytes = new byte[fs.Length];
//            BinaryReader br = new BinaryReader(fs);
//            imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
//            using (SqlConnection connection = new SqlConnection
//                ("Server=.;Database=image_test;Trusted_Connection=True"))
//            {
//                connection.Open();
//                SqlCommand command = new SqlCommand("insert into temp values(12345, @ImageList)", connection);
//                command.Parameters.Add("ImageList", SqlDbType.Image);
//                command.Parameters["ImageList"].Value = imagebytes;
//                command.ExecuteNonQuery();
//                MessageBox.Show("成功将图片存入SQL Server");
//            }
//        }
//    }
//}

//private void button2_Click(object sender, EventArgs e)
//{
//    byte[] imagebytes = null;
//    using (SqlConnection connection = new SqlConnection
//                ("Server=.;Database=image_test;Trusted_Connection=True"))
//    {
//        connection.Open();
//        SqlCommand command = new SqlCommand("select top 1 * from temp", connection);
//        using (SqlDataReader dr = command.ExecuteReader())
//        {
//            while (dr.Read())
//            {
//                imagebytes = (byte[])dr.GetValue(1);
//            }
//            command.Clone();
//        }
//    }
//    MemoryStream ms = new MemoryStream(imagebytes);
//    Bitmap bmpt = new Bitmap(ms);
//    pictureBox1.Image = bmpt;
//}





//static void Main(string[] args)
//{
//    string queryString = "SELECT * FROM Account1";
//    OperateSQL(queryString);
//}

//public static SqlConnection Connection()
//{
//    string constr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
//    return new SqlConnection(constr);
//}

//public static void OperateSQL(string queryString)
//{
//    using (SqlConnection connection = Connection())
//    {
//        SqlCommand command = new SqlCommand(queryString, connection);
//        connection.Open();
//        //写入
//        //command.ExecuteNonQuery();
//        //读取
//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                Console.WriteLine(String.Format("{0} {1} {2} {3} {4} {5}", reader[0], reader[1],
//                    reader[2], reader[3], reader[4], reader[5]));
//            }
//        }
//    }
//}



