using esports.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace esports.Api
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DataContext(DbContextOptions<DataContext> dbContext): base (dbContext)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(x => x.Username).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Team>().HasIndex(x => x.TeamName).IsUnique();
            modelBuilder.Entity<Tournament>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
