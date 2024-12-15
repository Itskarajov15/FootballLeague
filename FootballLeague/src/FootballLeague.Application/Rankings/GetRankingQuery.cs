using FootballLeague.Domain.Rankings;
using MediatR;

namespace FootballLeague.Application.Rankings;

public record GetRankingQuery() : IRequest<IEnumerable<Ranking>>;