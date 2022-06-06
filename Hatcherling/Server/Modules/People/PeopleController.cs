using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hatcherling.Server.Modules.People;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IService<Person> _peopleService;

    public PeopleController(IService<Person> peopleService)
    {
        _peopleService = peopleService;
    }

    // GET: api/<PeopleController>
    [HttpGet]
    public async Task<IEnumerable<Person>> Get()
    {
        return await _peopleService.GetAll();
    }

    // GET api/<PeopleController>/5
    [HttpGet("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        var person = await _peopleService.Get(id);

        if (person == null)
            return Results.NotFound();

        return Results.Ok(person);

    }

    // POST api/<PeopleController>
    [HttpPost]
    public async Task<IResult> Post(Person person)
    {
        try
        {
            await _peopleService.Insert(person);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    // PUT api/<PeopleController>/5
    [HttpPut]
    public async Task<IResult> Put(Person person)
    {
        try
        {
            await _peopleService.Update(person);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    // DELETE api/<PeopleController>/5
    [HttpDelete("{id}")]
    public async Task<IResult> Delete(Guid id)
    {
        try
        {
            await _peopleService.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
