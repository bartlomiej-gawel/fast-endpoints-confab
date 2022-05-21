using Confab.Modules.Conferences.Domain.Hosts;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Conferences.Infrastructure.Configurations;

internal class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("hosts");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .HasConversion(x => x.Value, x => HostId.From(x));

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion(x => x.Value, x => HostName.From(x));

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(1000)
            .HasConversion(x => x.Value, x => HostDescription.From(x));
    }
}