using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Shared;

namespace FootballLeague.Domain.Matches;

public sealed class Match : Entity
{
    private Match(
        Guid id,
        Guid team1Id,
        Guid team2Id,
        int team1Score,
        int team2Score,
        DateTime matchDate) 
        : base(id)
    {
        Team1Id = team1Id;
        Team2Id = team2Id;
        Team1Score = team1Score;
        Team2Score = team2Score;
        MatchDate = matchDate;
    }

    private Match()
    {
    }

    public Guid Team1Id { get; private set; }

    public Guid Team2Id { get; private set; }

    public int Team1Score { get; private set; }

    public int Team2Score { get; private set; }

    public DateTime MatchDate { get; private set; }

    public static Match Create(
        Guid team1Id,
        Guid team2Id, 
        int team1Score, 
        int team2Score,
        DateTime matchDate)
    {
        Guard.AgainstSameTeamIds(team1Id, team2Id);
        Guard.AgainstNegative(team1Score, nameof(team1Score));
        Guard.AgainstNegative(team2Score, nameof(team2Score));

        var match = new Match(
            Guid.NewGuid(),
            team1Id,
            team2Id,
            team1Score,
            team2Score,
            matchDate);

        return match;
    }
}
