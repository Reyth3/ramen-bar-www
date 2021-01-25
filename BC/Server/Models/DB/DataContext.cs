using BC.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Server.Models.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var reservation = modelBuilder.Entity<Reservation>();
            reservation.HasIndex(o => o.GuestsNumber);
            reservation.HasIndex(o => o.ReservationTime);

            var announcement = modelBuilder.Entity<Announcement>();
            announcement.HasIndex(o => o.PostingDate);

            var up = modelBuilder.Entity<UserProfile>();
            up.HasIndex(o => o.EmailAddress).IsUnique();
        }
    }
}
