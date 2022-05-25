namespace PostgreSQLDataAccess
{
    public interface IPostgreSQLSDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "PostgreSQL");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "PostgreSQL");
    }
}