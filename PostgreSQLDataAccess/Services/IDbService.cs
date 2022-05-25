namespace PostgreSQLDataAccess.Services
{
    internal interface IDbService
    {
        Task<T> GetAsync<T>(string command, object parms);
        Task<List<T>> GetAllAsync<T>(string command, object parms);
        Task<T> InsertAsync<T>(string command, object parms);
        Task<T> UpdateAsync<T>(string command, object parms);
        Task<T> DeleteAsync<T>(string command, object parms);
    }
}
