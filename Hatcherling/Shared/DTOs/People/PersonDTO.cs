namespace Hatcherling.Shared.DTOs.People;
public class PersonDTO
{
    public Guid Id { get; set; }
    public Guid OrganizationId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
}
