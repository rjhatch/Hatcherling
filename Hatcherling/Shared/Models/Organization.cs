using Hatcherling.Shared.Interfaces;

namespace Hatcherling.Shared.Models;
public class Organization : IModelBase
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime DateCreated { get; set; }
    public DateTime? DateDeleted { get; set; }

    //Navigation properties
    public List<Person>? People { get; set; }
}
