using Hatcherling.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class HatcherlingContext : DbContext
{
    public DbSet<Person>? People { get; set; }

    public HatcherlingContext(DbContextOptions<HatcherlingContext> options)
        : base(options) { }


}
