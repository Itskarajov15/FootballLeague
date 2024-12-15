using FootballLeague.Domain.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Infrastructure.Configurations;

internal sealed class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Wins)
            .IsRequired();

        builder.Property(t => t.Draws)
            .IsRequired();

        builder.Property(t => t.Losses)
            .IsRequired();

        builder.Property(t => t.MatchesPlayed)
            .IsRequired();

        builder.Property(t => t.CreatedAt)
            .IsRequired();
    }
}
