using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Users.Infrastructure;

internal class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users_module");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}