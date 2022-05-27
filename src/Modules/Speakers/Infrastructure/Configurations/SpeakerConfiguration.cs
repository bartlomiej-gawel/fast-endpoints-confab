using Confab.Modules.Speakers.Domain;
using Confab.Modules.Speakers.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Confab.Modules.Speakers.Infrastructure.Configurations;

internal class SpeakerConfiguration : IEntityTypeConfiguration<Speaker>
{
    public void Configure(EntityTypeBuilder<Speaker> builder)
    {
        builder.ToTable("speakers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id")
            .IsRequired()
            .HasConversion(x => x.Value, x => new SpeakerId(x));

        builder.Property(x => x.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(x => x.Value, x => new SpeakerEmail(x));

        builder.OwnsOne(x => x.FullName, y =>
        {
            y.Property(p => p.FirstName)
                .HasColumnName("first_name")
                .HasMaxLength(30)
                .IsRequired();

            y.Property(p => p.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(30)
                .IsRequired();
        });

        builder.Property(x => x.Bio)
            .HasColumnName("bio")
            .HasMaxLength(1000)
            .IsRequired()
            .HasConversion(x => x.Value, x => new SpeakerBio(x));

        builder.Property(x => x.AvatarUrl)
            .HasColumnName("avatar_url")
            .HasMaxLength(100)
            .IsRequired()
            .HasConversion(x => x.Value, x => new SpeakerAvatarUrl(x));
    }
}