using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasGG.Context
{
    public class ConnectionDatabase
    {
        private static readonly string connectionString =
        "Data Source=E5\\MSSQLSERVER2; Database=BookingRoom; Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection Get()
        {
            return new SqlConnection(connectionString);
        }

    }
}
