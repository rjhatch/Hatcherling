namespace Hatcherling.Shared.Models;
public class Organization
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Person>? People { get; set; }
}
