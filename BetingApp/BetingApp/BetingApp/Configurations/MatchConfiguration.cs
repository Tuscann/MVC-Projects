using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Match = BettingApp.Models.Match;

namespace BettingApp.Configurations
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.HasKey(match => match.Id);
            builder.HasMany(match => match.Bets)
              .WithOne(bet => bet.Match)
              .HasForeignKey(bet => bet.MatchId);

            builder.HasOne(match => match.Event)
                .WithMany(eve => eve.Matches)
                .HasForeignKey(match => match.EventId);

            builder.Property(match => match.Name)
                .HasMaxLength(128);

            builder.Property(match => match.MatchType)
               .HasMaxLength(16);
        }
    }
}
