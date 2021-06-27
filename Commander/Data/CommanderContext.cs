using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }

        public DbSet<Command> Commands { get; set; }        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Command>().HasKey(command => command.Id);
            modelBuilder.Entity<Command>().Property(command => command.HowTo).IsRequired();
            modelBuilder.Entity<Command>().Property(command => command.HowTo).HasColumnType("nvarchar(250)");
            modelBuilder.Entity<Command>().Property(command => command.Line).IsRequired();
            modelBuilder.Entity<Command>().Property(command => command.Platform).IsRequired();
        }
    }
}