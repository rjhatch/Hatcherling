using Hatcherling.Shared.DTOs.People;
using Microsoft.AspNetCore.Mvc;

namespace Hatcherling.Server.Modules.People;
[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly HatcherlingContext _context;

    public PeopleController(HatcherlingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<ServiceResponse<List<Person>>> GetAllPeople()
    {
        var people = _context.People.Where(p => p.DateDeleted == null).ToList();

        if (people.Any())
        {
            return Ok(new ServiceResponse<List<Person>>
            {
                Data = people
            });
        }
        else
        {
            return Ok(new ServiceResponse<List<Person>>
            {
                Success = false,
                Message = "No people found."
            });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<PersonDTO> GetPerson(Guid id)
    {
        var person = _context.People.FirstOrDefault(p => p.Id == id);

        var response = new ServiceResponse<PersonDTO>();

        if (person != null && person.DateDeleted == null)
        {
            var foundPerson = new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Email = person.Email
            };

            response.Data = foundPerson;

            return Ok(response);
        }
        else
        {
            response.Success = false;
            response.Message = "That person was not found.";

            return NotFound(response);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<Guid>>> CreatePerson(PersonDTO person)
    {
        Person newPerson = new Person
        {
            FirstName = person.FirstName,
            LastName = person.LastName,
            Email = person.Email,
            OrganizationId = person.OrganizationId
        };

        await _context.People.AddAsync(newPerson);
        await _context.SaveChangesAsync();

        return Ok(new ServiceResponse<Guid> { Data = newPerson.Id });
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        var deletedPerson = _context.People.FirstOrDefault(p => p.Id == id);

        if (deletedPerson != null)
        {
            deletedPerson.DateDeleted = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
