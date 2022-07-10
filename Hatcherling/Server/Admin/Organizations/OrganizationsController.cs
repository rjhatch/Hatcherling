using Hatcherling.Shared.DTOs.Organizations;
using Microsoft.AspNetCore.Mvc;

namespace Hatcherling.Server.Admin.Organizations;
[Route("api/admin/[controller]")]
[ApiController]
public class OrganizationsController : ControllerBase
{
    private readonly HatcherlingContext _context;

    public OrganizationsController(HatcherlingContext context)
    {
        _context = context;
    }

    // GET: api/<OrganizationsController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<OrganizationsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<OrganizationsController>
    [HttpPost]
    public ActionResult<ServiceResponse<Guid>> CreateOrganization(OrganizationDTO organization)
    {
        var newOrganization = new Organization
        {
            Name = organization.Name
        };

        _context.Organizations.Add(newOrganization);
        _context.SaveChanges();

        return Ok(new ServiceResponse<Guid> { Data = newOrganization.Id });
    }

    // PUT api/<OrganizationsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OrganizationsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
