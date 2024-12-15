using MediatR;

namespace FootballLeague.Application.Matches.DeleteMatch;

public record DeleteMatchCommand(Guid MatchId) : IRequest;