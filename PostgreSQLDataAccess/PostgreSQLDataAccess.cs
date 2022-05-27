using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace PostgreSQLDAL;

public class PostgreSQLDataAccess : IPostgreSQLDataAccess
{
    private readonly IConfiguration _config;

    public PostgreSQLDataAccess(IConfiguration config)
    {
        _config = config;

        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string command,
        U parameters,
        string connectionId = "PostgreSQL")
    {
        using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(command, parameters);
    }

    public async Task SaveData<T>(
        string command,
        T parameters,
        string connectionId = "PostgreSQL")
    {
        using var connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(command, parameters);
    }
}
