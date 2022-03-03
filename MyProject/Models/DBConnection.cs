
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MyProject.Models
{
    public class DBConnection
    {
        public SqlConnection Connection;
        public DBConnection()
        {
            Connection = new SqlConnection(ApplicationDBConfig.ConnectionStr);
        }
    }
}
