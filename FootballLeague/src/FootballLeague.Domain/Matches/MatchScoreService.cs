using FootballLeague.Domain.Teams;

namespace FootballLeague.Domain.Matches;

public class MatchScoreService
{
    public void AddPointsToTeams(
        Match match,
        Team team1,
        Team team2)
    {
        (int team1Points, int team2Points) = CalculatePoints(match.Team1Score, match.Team2Score);

        team1.AddPoints(team1Points);
        team2.AddPoints(team2Points);
    }

    public void RemovePointsFromTeams(
        Match match,
        Team team1,
        Team team2)
    {
        (int team1Points, int team2Points) = CalculatePoints(match.Team1Score, match.Team2Score);

        team1.RemovePoints(team1Points);
        team2.RemovePoints(team2Points);
    }

    private (int team1Points, int team2Points) CalculatePoints(
        int team1Score,
        int team2Score)
    {
        if (team1Score > team2Score)
        {
            return (3, 0);
        }
        else if (team1Score < team2Score)
        {
            return (0, 3);
        }
        else
        {
            return (1, 1);
        }
    }
}
