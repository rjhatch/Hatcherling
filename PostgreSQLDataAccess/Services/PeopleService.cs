using Hatcherling.Shared.Models;

namespace PostgreSQLDAL.Services;

public class PeopleService : IService<Person>
{
    private readonly IPostgreSQLDataAccess _db;

    public PeopleService(IPostgreSQLDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Person>> GetAll() =>
        await _db.LoadData<Person, dynamic>("select * from people;", new { });

    public async Task<Person?> Get(Guid id)
    {
        var results = await _db.LoadData<Person, dynamic>("select * from people where id = @Id;",
            new { Id = id });

        return results.FirstOrDefault();
    }

    public async Task Insert(Person person) =>
        await _db.SaveData("insert into people (first_name, last_name, fk_organization) values (@FirstName, @LastName, @FKOrganization);",
            person);

    public async Task Update(Person person) =>
        await _db.SaveData("update people set (first_name, last_name, fk_organization) = (@FirstName, @LastName, @FKOrganization)" +
            "where id = @Id;", person);

    public Task Delete(Guid id) =>
        _db.SaveData("delete from people where id = @Id;", new { Id = id });
}