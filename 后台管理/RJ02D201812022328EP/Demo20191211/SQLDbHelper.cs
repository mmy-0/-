using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo20191211
{
    public class SQLDbHelper
    {
        public static string strConn = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123;";
        //连接字符串的其他写法
        //string constr = "server=.;database=Palm_SC_Electric;integrated security=SSPI";//2windows
        //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";//3:sql

        public static bool GetConnettion()///测试连接
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    return true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }//测试数据库连接代码

        public static int ExecuteNonQuery(string sql, SqlParameter[] param)
        {
            int result = 0;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
                    if (param != null)
                        sqlCmd.Parameters.AddRange(param);
                    result = sqlCmd.ExecuteNonQuery();/////////////
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }//执行数据库的“增删改”,返回受影响的记录数（行数）




    }
}
