using Dapper;
using Npgsql;

namespace PostgreSQLDataAccess
{
    public class PostgreSQLConnection
    {
        private readonly PostgreSQLConnection _connection;

        public PostgreSQLConnection()
        {

        }

        public void Connect()
        {
            using (var connection = new NpgsqlConnection("Host=localhost:5433;Username=postgres;Password=postgres;Database=Hatcherling;"))
            {
                connection.Open();
                connection.Execute(@" insert into people (first_name, last_name, fk_organization) values
                                        ('John', 'Doe', (select id from organizations where name = 'Total Defense'))
                                    ");
            }
        }
    }
}
