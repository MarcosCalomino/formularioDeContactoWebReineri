using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataBase
{
    public class Adapter
    {
        public SqlConnection sqlConn = Adapter.NewSqlConn();

        protected void OpenConnection()
        {
            if (sqlConn == null)
                sqlConn = Adapter.NewSqlConn();
            sqlConn.Open();
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
        }

        private static SqlConnection NewSqlConn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString);
        }
        //ConfigurationManager.ConnectionStrings["ConnStringLocal"].ConnectionString  stringConexion
    }
}
