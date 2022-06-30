using Hatcherling.Shared.Models.Interfaces;

namespace Hatcherling.Shared.Models;
public class Organization : IModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? DateDeleted { get; set; }

    //navigation properties
    public ICollection<Person>? People { get; set; }
}
