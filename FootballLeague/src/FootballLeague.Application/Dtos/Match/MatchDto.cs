namespace FootballLeague.Application.Dtos.Match;

public class MatchDto
{
    public Guid Id { get; set; }

    public string Team1Name { get; set; } = null!;

    public string Team2Name { get; set; } = null!;

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public DateTime MatchDate { get; set; }
}
