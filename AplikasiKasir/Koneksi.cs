using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AplikasiKasir
{
    internal class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source = localhost\\MSSQLSERVER01;initial catalog = DB_KASIR;integrated security=true";
            return Conn;
        }
    }
}
