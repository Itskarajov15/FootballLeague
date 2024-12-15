using FootballLeague.Domain.Rankings;
using MediatR;

namespace FootballLeague.Application.Rankings;

internal sealed class GetRankingQueryHandler : IRequestHandler<GetRankingQuery, IEnumerable<Ranking>>
{
    private readonly IRankingRepository _rankingRepository;

    public GetRankingQueryHandler(IRankingRepository rankingRepository)
    {
        _rankingRepository = rankingRepository;
    }

    public async Task<IEnumerable<Ranking>> Handle(GetRankingQuery request, CancellationToken cancellationToken)
    {
        return await _rankingRepository.GetRankingsAsync();
    }
}
