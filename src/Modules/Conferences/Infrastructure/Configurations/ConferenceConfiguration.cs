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
            .HasConversion(x => x.Value, x => ConferenceId.From(x));

        builder.Property(x => x.HostId)
            .HasColumnName("host_id")
            .IsRequired()
            .HasConversion(x => x.Value, x => HostId.From(x));

        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(x => x.Value, x => ConferenceName.From(x));

        builder.Property(x => x.Description)
            .HasColumnName("description")
            .HasMaxLength(1000)
            .IsRequired()
            .HasConversion(x => x.Value, x => ConferenceDescription.From(x));

        builder.Property(x => x.Location)
            .HasColumnName("location_city")
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(x => x.Value.City, x => new ConferenceLocation());
        
        builder.Property(x => x.Location.Value.Street)
            .HasColumnName("location_street")
            .HasMaxLength(100)
            .IsRequired();
        
        // builder.OwnsOne(x => x.Location, x =>
        // {
        //     x.Property(p => p.Value.City)
        //         .HasColumnName("location_city")
        //         .HasMaxLength(100)
        //         .IsRequired();
        //
        //     x.Property(p => p.Value.Street)
        //         .HasColumnName("location_street")
        //         .HasMaxLength(100)
        //         .IsRequired();
        //
        //     x.WithOwner();
        // });

        builder.Property(x => x.ParticipantsLimit)
            .HasColumnName("participants_limit")
            .HasConversion(x => x.Value, x => ConferenceParticipantsLimit.From(x));

        builder.Property(x => x.Date.Value.From)
            .HasColumnName("date_from")
            .IsRequired();

        builder.Property(x => x.Date.Value.To)
            .HasColumnName("date_to")
            .IsRequired();
    }
}