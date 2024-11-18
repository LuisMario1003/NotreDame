using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotreDame.DAL
{
    public class DatabaseHelper
    {
        private const string ConnectionString = "Server=localhost;Database=NotreDameDB;Uid=root;Pwd=1003;"; 
        public static MySqlConnection GetConnection() 
        { 
            return new MySqlConnection(ConnectionString); 
        }
    }
}
