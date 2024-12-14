using MediatR;

namespace FootballLeague.Application.Matches.AddMatch;

public record AddMatchCommand(
        Guid Team1Id,
        Guid Team2Id,
        int Team1Score,
        int Team2Score,
        DateTime MatchDate) : IRequest<Guid>;