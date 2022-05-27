namespace PostgreSQLDAL;

public interface IPostgreSQLDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string command, U parameters, string connectionId = "PostgreSQL");
    Task SaveData<T>(string command, T parameters, string connectionId = "PostgreSQL");
}