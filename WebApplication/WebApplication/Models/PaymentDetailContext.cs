using Microsoft.EntityFrameworkCore;

namespace WebApplication.Models
{
    public class PaymentDetailContext : DbContext
    {

        private const string connectionString = "Server=localhost\\MSSQLSERVER07;Database=PaymentDetailDb;Trusted_Connection=True;MultipleActiveResultSets=True;";

        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options) : base(options)
        {

        }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        // Fluent API - Relationships

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentDetail>().HasKey(payment => payment.PaymentDetailId);
            modelBuilder.Entity<PaymentDetail>().Property(payment => payment.CardNumber).HasColumnType("nvarchar(16)");
            modelBuilder.Entity<PaymentDetail>().Property(payment => payment.CardOwnerName).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<PaymentDetail>().Property(payment => payment.ExpirationDate).HasColumnType("nvarchar(5)");
            modelBuilder.Entity<PaymentDetail>().Property(payment => payment.SecurityCode).HasColumnType("nvarchar(3)");
        }
    }
}