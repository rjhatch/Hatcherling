using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace PostgreSQLDataAccess;

public class PostgreSQLSDataAccess : IPostgreSQLSDataAccess
{
    private readonly IConfiguration _config;

    public PostgreSQLSDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "PostgreSQL")
    {
        using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "PostgreSQL")
    {
        using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
