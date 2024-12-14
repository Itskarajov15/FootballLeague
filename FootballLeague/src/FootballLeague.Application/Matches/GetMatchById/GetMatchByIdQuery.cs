using FootballLeague.Application.Dtos.Match;
using MediatR;

namespace FootballLeague.Application.Matches.GetMatchById;

public record GetMatchByIdQuery(Guid Id) : IRequest<MatchDto>;