using AutoMapper;
using FootballLeague.Application.Dtos.Match;
using FootballLeague.Domain.Matches;
using MediatR;

namespace FootballLeague.Application.Matches.GetAllMatches;

internal sealed class GetAllMatchesQueryHandler : IRequestHandler<GetAllMatchesQuery, IEnumerable<MatchDto>>
{
    private readonly IMatchRepository _matchRepository;
    private readonly IMapper _mapper;

    public GetAllMatchesQueryHandler(
        IMatchRepository matchRepository,
        IMapper mapper)
    {
        _matchRepository = matchRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MatchDto>> Handle(GetAllMatchesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Match> matches = await _matchRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<MatchDto>>(matches);
    }
}
