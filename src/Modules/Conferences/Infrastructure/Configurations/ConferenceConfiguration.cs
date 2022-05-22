using Confab.Modules.Conferences.Domain.Conferences;
using Confab.Modules.Conferences.Domain.Conferences.ValueObjects;
using Confab.Modules.Conferences.Domain.Hosts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Conferences.Infrastructure.Configurations;

internal class ConferenceConfiguration : IEntityTypeConfiguration<Conference>
{
    public void Configure(EntityTypeBuilder<Conference> builder)
    {
        builder.ToTable("conferences");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .HasConversion(x => x.Value, x => new ConferenceId(x));

        builder.Property(x => x.HostId)
            .HasColumnName("host_id")
            .IsRequired()
            .HasConversion(x => x.Value, x => new HostId(x));

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(x => x.Value, x => new ConferenceName(x));

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(1000)
            .IsRequired()
            .HasConversion(x => x.Value, x => new ConferenceDescription(x));

        builder.OwnsOne(x => x.Location, y =>
        {
            y.Property(p => p.City)
                .HasColumnName("location_city")
                .HasMaxLength(50)
                .IsRequired();

            y.Property(p => p.Street)
                .HasColumnName("location_street")
                .HasMaxLength(50)
                .IsRequired();
        });

        builder.Property(x => x.ParticipantsLimit)
            .HasColumnName("participants_limit")
            .HasConversion(x => x.Value, x => new ConferenceParticipantsLimit(x));

        builder.OwnsOne(x => x.Date, y =>
        {
            y.Property(p => p.From)
                .HasColumnName("date_from")
                .IsRequired();

            y.Property(p => p.To)
                .HasColumnName("date_to")
                .IsRequired();
        });
    }
}