using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Domain.Hosts;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Conferences.Infrastructure;

internal class ConferencesDbContext : DbContext
{
    public DbSet<Host> Hosts { get; set; } = null!;
    public DbSet<Conference> Conferences { get; set; } = null!;

    public ConferencesDbContext(DbContextOptions<ConferencesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("conferences_module");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}