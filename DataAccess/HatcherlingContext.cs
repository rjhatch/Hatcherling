using Hatcherling.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class HatcherlingContext : DbContext
{
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Organization> Organizations { get; set; } = null!;
    public DbSet<Login> LoginInformation { get; set; } = null!;

    public HatcherlingContext(DbContextOptions<HatcherlingContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

}
