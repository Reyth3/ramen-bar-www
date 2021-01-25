﻿// <auto-generated />
using System;
using BC.Server.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BC.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210123223828_AnnouncementFix")]
    partial class AnnouncementFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("BC.Shared.Models.Announcement", b =>
                {
                    b.Property<int>("AnnouncementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AuthorUserProfileId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("PostingDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Preview")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Text")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Thumbnail")
                        .HasMaxLength(1048576)
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AnnouncementId");

                    b.HasIndex("AuthorUserProfileId");

                    b.HasIndex("PostingDate");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("BC.Shared.Models.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ItemName")
                        .HasMaxLength(96)
                        .HasColumnType("nvarchar(96)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("MenuItemId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("BC.Shared.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("GuestsNumber")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerUserProfileId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("ReservationTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ReservationId");

                    b.HasIndex("GuestsNumber");

                    b.HasIndex("OwnerUserProfileId");

                    b.HasIndex("ReservationTime");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BC.Shared.Models.UserProfile", b =>
                {
                    b.Property<int>("UserProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsEditor")
                        .HasMaxLength(128)
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(48)
                        .HasColumnType("nvarchar(48)");

                    b.HasKey("UserProfileId");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("BC.Shared.Models.Announcement", b =>
                {
                    b.HasOne("BC.Shared.Models.UserProfile", "Author")
                        .WithMany("PostedAnnouncements")
                        .HasForeignKey("AuthorUserProfileId");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BC.Shared.Models.Reservation", b =>
                {
                    b.HasOne("BC.Shared.Models.UserProfile", "Owner")
                        .WithMany("Reservations")
                        .HasForeignKey("OwnerUserProfileId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("BC.Shared.Models.UserProfile", b =>
                {
                    b.Navigation("PostedAnnouncements");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}