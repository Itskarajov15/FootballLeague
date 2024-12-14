namespace FootballLeague.Domain.Matches;

public class MatchScoreService
{
    public (int team1Points, int team2Points) CalculatePoints(int team1Score, int team2Score)
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
