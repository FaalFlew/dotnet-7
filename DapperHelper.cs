using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

public class DapperHelper
{
    private readonly string _connectionString;

    public DapperHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<T> Query<T>(string sql, object parameters = null)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        dbConnection.Open();
        return dbConnection.Query<T>(sql, parameters);
    }

    // Add other Dapper methods as needed.
}
