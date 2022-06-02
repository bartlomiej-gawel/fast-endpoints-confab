using Confab.Modules.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace Confab.Modules.Users.Infrastructure;

internal class UsersDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users_module");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}