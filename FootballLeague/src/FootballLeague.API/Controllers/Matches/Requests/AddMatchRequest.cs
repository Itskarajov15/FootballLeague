namespace FootballLeague.API.Controllers.Matches.Requests;

public record AddMatchRequest(
    Guid Team1Id,
    Guid Team2Id,
    int Team1Score,
    int Team2Score,
    DateTime MatchDate);