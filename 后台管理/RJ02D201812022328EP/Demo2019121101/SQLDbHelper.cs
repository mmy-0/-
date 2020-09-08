using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2019121101
{
    public class SQLDbHelper
    {
        //连接sql数据库字符串
        public static string strConn = "server=(local);database=Palm_SC_Electric;uid=sa;pwd=123;";
        //连接字符串的其他写法
        //string constr = "server=.;database=Palm_SC_Electric;integrated security=SSPI";//2windows
        //string constr = "data source=.;initial catalog=myschool;user id=sa;pwd=sa";//3:sql

        public static bool GetConnettion()
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
    }
}
