using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 后台管理
{
    public static class MySqlManage
    {
        public static string connection = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";

        /// <summary> 
        /// 查询的sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>键值对的形式返回多个一对多的数据</returns>
        public static Dictionary<string, List<string>> GetQuery(string sql, int columnNum)
        {
            Dictionary<string, List<string>> d = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                d = new Dictionary<string, List<string>>();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> list = new List<string>();
                            for (int i = 0; i <= columnNum; i++)
                            {
                                list.Add(reader[i].ToString());
                            }
                            d.Add(reader[0].ToString(), list);
                        }
                    }
                }
            }
            return d;
        }
        /// <summary>
        /// 只限于得到单条内容的sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<string> GetContent(string sql, int columnNum)
        {
            List<string> list = new List<string>();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //for (int i = 0; i <= columnNum; i++)
                            //{
                                list.Add(reader[5].ToString());
                           // }
                        }
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 普通的sql语句
        /// </summary>
        /// <param name="sql"></param>
        public static void Sentence(string sql)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
            }
        }
    }
}
