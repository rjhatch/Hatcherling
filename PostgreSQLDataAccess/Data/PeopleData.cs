using Hatcherling.Shared.Models;

namespace PostgreSQLDataAccess.Data;

public class PeopleData
{
    private readonly IPostgreSQLSDataAccess _db;

    public PeopleData(IPostgreSQLSDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<Person>> GetPeople() =>
        _db.LoadData<Person, dynamic>(storedProcedure: "spPeople_GetAll", new { });

    public async Task<Person?> GetPerson(string id)
    {
        var results = await _db.LoadData<Person, dynamic>(storedProcedure: "spPerson_Get",
            new { id });

        return results.FirstOrDefault();
    }

    public Task InsertPerson(Person person) =>
        _db.SaveData(storedProcedure: "spPerson_Insert", new { person.FirstName, person.LastName, person.FKOrganization });

    public Task UpdatePerson(Person person) =>
        _db.SaveData(storedProcedure: "spPerson_Update", person);

    public Task DeletePerson(string id) =>
        _db.SaveData(storedProcedure: "spPerson_Delete", new { id });
}