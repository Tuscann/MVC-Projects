using BettingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BettingApp.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(eve => eve.Sport)
                .WithMany(sport => sport.Events)
                .HasForeignKey(eve => eve.SportId);

            //builder.HasMany(match => match.Matches)
            //    .WithOne(eve => eve.Event)
            //    .HasForeignKey(eve => eve.EventId);

            builder.Property(x => x.Name)
                .HasMaxLength(128);
        }
    }
}
