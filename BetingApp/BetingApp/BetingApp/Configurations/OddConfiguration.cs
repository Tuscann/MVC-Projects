using BettingApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingApp.Configurations
{
    public class OddConfiguration
    {
        public void Configure(EntityTypeBuilder<Odd> builder)
        {
            builder.HasKey(odd => odd.Id);
            builder.HasOne(odd => odd.Bet)
                .WithMany(bet => bet.Odds)
                .HasForeignKey(odd => odd.BetId);

            builder.Property(odd => odd.Name)
                .HasMaxLength(128);

            builder.Property(odd => odd.Id)
                .HasMaxLength(16);
        }
    }
}
