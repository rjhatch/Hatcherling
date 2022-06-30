using Hatcherling.Shared.Models.Interfaces;

namespace Hatcherling.Shared.Models;

public class Person : IModelBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTime? DateDeleted { get; set; }

    //navigation properties
    public List<Organization> Organizations { get; set; } = null!;

    public Login? Login { get; set; }
}
