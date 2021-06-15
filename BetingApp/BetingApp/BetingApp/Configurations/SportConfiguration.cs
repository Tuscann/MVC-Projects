using BettingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingApp.Configurations
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Events)
                .WithOne(e => e.Sport)
                .HasForeignKey(x => x.SportId);

            builder.Property(x => x.Name)
                .HasMaxLength(128);
        }
    }
}
