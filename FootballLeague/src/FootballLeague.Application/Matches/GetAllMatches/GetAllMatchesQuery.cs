using FootballLeague.Application.Dtos.Match;
using MediatR;

namespace FootballLeague.Application.Matches.GetAllMatches;

public record GetAllMatchesQuery() : IRequest<IEnumerable<MatchDto>>;