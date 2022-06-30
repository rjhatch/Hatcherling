namespace Hatcherling.Shared.Models;
public class Login
{
    public Guid Id { get; set; }
    public byte[] PasswordHash { get; set; } = null!;
    public byte[] PasswordSalt { get; set; } = null!;
    public Guid PersonId { get; set; }
    public Person Person { get; set; } = null!;
}
