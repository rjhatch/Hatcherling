using Npgsql;

namespace PostgreSQLDataAccess.Services
{
    public class DbService : IDbService
    {
        private readonly NpgsqlConnection _db;

        public DbService(config)
        {
            _db = new NpgsqlConnection(config.GetConnectionString(""));
        }

        public Task<T> Delete<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAll<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<T> Insert<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T>(string command, object parms)
        {
            throw new NotImplementedException();
        }
    }
}
