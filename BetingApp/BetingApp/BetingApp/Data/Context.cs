using BettingApp.Configurations;
using BettingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BettingApp.Data
{
    public class UltraPlayDbContext : DbContext
    {
        public UltraPlayDbContext(DbContextOptions<UltraPlayDbContext> options)
            : base(options)
        {}

        public DbSet<Sport> Sports { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Odd> Odds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SportConfiguration());
            modelBuilder.ApplyConfiguration(new MatchConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER07;Database=UltraPlay;Trusted_Connection=True;");
            }
        }
    }
}
