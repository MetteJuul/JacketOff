using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess {
    public abstract class BaseDB {
        private string _connectionString;
        protected BaseDB(string connectionString) => _connectionString = connectionString;
        protected SqlConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
