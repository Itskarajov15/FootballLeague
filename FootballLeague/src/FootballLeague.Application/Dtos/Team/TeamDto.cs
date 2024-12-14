namespace FootballLeague.Application.Dtos.Team;

public class TeamDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int MatchesPlayed { get; set; }

    public int Wins { get; set; }

    public int Draws { get; set; }

    public int Losses { get; set; }
}
