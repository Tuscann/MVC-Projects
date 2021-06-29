using BookListRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(s => s.Id);
            modelBuilder.Entity<Book>().Property(s => s.Name).IsRequired();
        }
    }
}
