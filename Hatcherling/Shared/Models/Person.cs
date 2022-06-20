namespace Hatcherling.Shared.Models;

public class Person
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public ICollection<Organization> Organizations { get; set; } = null!;
}
