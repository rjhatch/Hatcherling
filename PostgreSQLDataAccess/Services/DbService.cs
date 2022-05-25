using Microsoft.Extensions.Configuration;

namespace PostgreSQLDataAccess.Services
{
    public class DbService : IDbService
    {
        private readonly IConfiguration _db;

        public DbService(IConfiguration config)
        {
            _db = config;
        }

        public Task<T> DeleteAsync<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllAsync<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<T> InsertAsync<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }
    }
}
