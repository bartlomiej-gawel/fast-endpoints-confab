using Confab.Modules.Speakers.Domain;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Speakers.Infrastructure;

internal class SpeakersDbContext : DbContext
{
    public DbSet<Speaker> Speakers { get; set; } = null!;

    public SpeakersDbContext(DbContextOptions<SpeakersDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("speakers_module");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}