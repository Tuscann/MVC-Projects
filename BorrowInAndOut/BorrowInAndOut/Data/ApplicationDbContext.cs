using BorrowInAndOut.Models__DomainClasses_;
using Microsoft.EntityFrameworkCore;

namespace BorrowInAndOut.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}