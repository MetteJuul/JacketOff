using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DataAccess {
    public abstract class BaseDB {
        private string _connectionString;
        protected BaseDB(string connectionString) => _connectionString = connectionString;
        protected IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
