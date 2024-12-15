namespace FootballLeague.Application.Dtos.Match;

public class MatchDto
{
    public Guid Id { get; set; }

    public Guid Team1Id { get; set; }

    public Guid Team2Id { get; set; }

    public int Team1Score { get; set; }

    public int Team2Score { get; set; }

    public DateTime MatchDate { get; set; }
}
