using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettingApp.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingApp.Configurations
{
    public class BetConfiguration
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(bet => bet.Id);
            builder.HasMany(bet => bet.Odds)
                .WithOne(odd => odd.Bet)
                .HasForeignKey(odd => odd.BetId);

            builder.HasOne(bet => bet.Match)
                .WithMany(match => match.Bets)
                .HasForeignKey(match => match.Id);

            builder.Property(bet => bet.Name)
                .HasMaxLength(128);

            builder.Property(bet => bet.Match)
                .HasMaxLength(16);
        }
    }
}
