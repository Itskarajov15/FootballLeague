namespace FootballLeague.Domain.Rankings;

public class Ranking
{
    public string TeamName { get; set; } = null!;

    public int NumberOfGames { get; set; }

    public int Wins { get; set; }

    public int Draws { get; set; }

    public int Losses { get; set; }

    public int Points { get; set; }

    public int GoalsScored { get; set; }
}
