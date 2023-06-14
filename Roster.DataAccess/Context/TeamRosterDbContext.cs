using Microsoft.EntityFrameworkCore;
using Roster.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.DataAccess.Context
{
    public class TeamRosterDbContext : DbContext
    {
        public TeamRosterDbContext(DbContextOptions options) : base(options)
        {
        }

        protected TeamRosterDbContext()
        {
        }
        public DbSet<TeamRosters> Rosters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamRosters>(
                entity =>
                {
                    entity.ToTable("TeamRosters");
                    entity.HasKey(e => e.PlayerID);
                    entity.Property(e => e.PlayerID);
                    entity.Property(e => e.TeamName).HasMaxLength(50);
                    entity.Property(e => e.FirstName);
                    entity.Property(e => e.LastName);
                    entity.Property(e => e.Age);
                    entity.Property(e => e.Sport);
                    entity.Property(e => e.Position);
                }
                );
        }

    }
}
