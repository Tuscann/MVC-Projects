using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace Library
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Patron> Patrons { get; set; }
    }
}
