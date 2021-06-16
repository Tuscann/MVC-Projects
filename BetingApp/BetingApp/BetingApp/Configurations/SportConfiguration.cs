using BettingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingApp.Configurations
{
    public class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasKey(sport => sport.Id);

            builder.HasMany(sport => sport.Events)
                .WithOne(even => even.Sport)
                .HasForeignKey(even => even.SportId);

            builder.Property(sport => sport.Name)
                .HasMaxLength(128);
        }
    }
}
