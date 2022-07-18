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

    [HttpGet]
    public ActionResult<ServiceResponse<List<Organization>>> GetAllOrganizations()
    {
        var organizations = _context.Organizations.Where(o => o.DateDeleted == null).ToList();

        if (organizations.Any())
        {
            return Ok(new ServiceResponse<List<Organization>>
            {
                Data = organizations
            });
        }
        else
        {
            return Ok(new ServiceResponse<List<Organization>>
            {
                Success = false,
                Message = "No organizations found."
            });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<OrganizationDTO> GetOrganization(Guid id)
    {
        var organization = _context.Organizations.FirstOrDefault(o => o.Id == id);

        var response = new ServiceResponse<OrganizationDTO>();

        if (organization != null && organization.DateDeleted == null)
        {
            var foundOrganization = new OrganizationDTO
            {
                Id = organization.Id,
                Name = organization.Name
            };

            response.Data = foundOrganization;

            return Ok(response);
        }
        else
        {
            response.Success = false;
            response.Message = "That organization was not found.";

            return NotFound(response);
        }
    }

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

    [HttpPut("{id}")]
    public void Put(Guid id, [FromBody] OrganizationDTO organization)
    {
    }

    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
        var deletedOrganization = _context.Organizations.FirstOrDefault(o => o.Id == id);

        if (deletedOrganization != null)
        {
            deletedOrganization.DateDeleted = DateTime.UtcNow;
            _context.SaveChanges();
        }
    }
}
