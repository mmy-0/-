using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ02D201812022328EP
{
    public class SQLDbHelper//辅助数据库操作类
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
        public static int ExecuteNonQuery(string sql,SqlParameter[] param)
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
        public static SqlDataReader ExecuteReader(string sql,SqlParameter[] param)
        {
            SqlDataReader dr = null;
            SqlConnection sqlConn = new SqlConnection(strConn);
            try
            {
                sqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);                
                if (param != null)
                    sqlCmd.Parameters.AddRange(param);
                dr = sqlCmd.ExecuteReader(CommandBehavior.CloseConnection);////////////////
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }//执行数据库的查询操作,返回DateReader对象
        public static object ExecuteScalar(string sql,  SqlParameter[] param)
        {
            object o = null;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);                    
                    if (param != null)
                        sqlCmd.Parameters.AddRange(param);
                    o = sqlCmd.ExecuteScalar();/////////////
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return o;
        }//执行数据库的统计查询操作,返回结果集中首行首列的object对象

    }
}
