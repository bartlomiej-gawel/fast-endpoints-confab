﻿// <auto-generated />
using System;
using Confab.Modules.Speakers.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Confab.Modules.Speakers.Infrastructure.Migrations
{
    [DbContext(typeof(SpeakersDbContext))]
    partial class SpeakersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("speakers_module")
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Confab.Modules.Speakers.Domain.Speaker", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("AvatarUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("avatar_url");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("bio");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.HasKey("Id");

                    b.ToTable("speakers", "speakers_module");
                });

            modelBuilder.Entity("Confab.Modules.Speakers.Domain.Speaker", b =>
                {
                    b.OwnsOne("Confab.Modules.Speakers.Domain.ValueObjects.SpeakerFullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("SpeakerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)")
                                .HasColumnName("first_name");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("character varying(30)")
                                .HasColumnName("last_name");

                            b1.HasKey("SpeakerId");

                            b1.ToTable("speakers", "speakers_module");

                            b1.WithOwner()
                                .HasForeignKey("SpeakerId");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}