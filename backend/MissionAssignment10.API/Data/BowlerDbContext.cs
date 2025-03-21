using Microsoft.EntityFrameworkCore;
using MissionAssignment10.API.Models;

namespace MissionAssignment10.API.Data
{
    public class BowlerDbContext : DbContext
    {
        public BowlerDbContext(DbContextOptions<BowlerDbContext> options) : base(options)
        {
        }

        public DbSet<Bowler> Bowlers { get; set; }
        public DbSet<Team> Teams { get; set; }

        //Add this method inside the class to ensure the EF maps the class Bowler to Bowlers (It was being weird)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bowler>().ToTable("Bowlers");
            modelBuilder.Entity<Team>().ToTable("Teams"); // optional but recommended
        }
    }
}

