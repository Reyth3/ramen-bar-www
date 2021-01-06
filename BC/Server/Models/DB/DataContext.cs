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

        public virtual DbSet<Goal> Goals { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var goals = modelBuilder.Entity<Goal>();
            goals.HasIndex(o => o.Difficulty);
            goals.HasIndex(o => o.IsCompleted);
            goals.HasIndex(o => o.ExpectedDeadline);

            var up = modelBuilder.Entity<UserProfile>();
            up.HasIndex(o => o.EmailAddress).IsUnique();
        }
    }
}
