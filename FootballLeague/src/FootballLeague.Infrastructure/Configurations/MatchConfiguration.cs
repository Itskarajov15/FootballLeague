using FootballLeague.Domain.Matches;
using FootballLeague.Domain.Teams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballLeague.Infrastructure.Configurations;

internal sealed class MatchConfiguration : IEntityTypeConfiguration<Match>
{
    public void Configure(EntityTypeBuilder<Match> builder)
    {
        builder.HasKey(m => m.Id);

        builder
            .HasOne<Team>()
            .WithMany()
            .HasForeignKey(m => m.Team1Id);

        builder
            .HasOne<Team>()
            .WithMany()
            .HasForeignKey(m => m.Team2Id);

        builder.Property(m => m.Team2Id)
            .IsRequired();

        builder.Property(m => m.Team1Score)
            .IsRequired();

        builder.Property(m => m.Team2Score)
            .IsRequired();

        builder.Property(m => m.MatchDate)
            .IsRequired();

        builder.Property(m => m.CreatedAt)
            .IsRequired();
    }
}
