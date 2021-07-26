using DotNet6_webApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet6_webApp.Data
{
    public class ContactDbContext:DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(contact => contact.Id);
            modelBuilder.Entity<Contact>().Property(contact => contact.FirstName).IsRequired();
        }
    }
}
