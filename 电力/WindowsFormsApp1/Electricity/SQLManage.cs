using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Electricity
{
    class SQLManage
    {
        public static SqlConnection Connection()
        {
            string constr = "Server=.;Database=Chuandian_on_palm;Trusted_Connection=True";
            return new SqlConnection(constr);
        }
    }
}
