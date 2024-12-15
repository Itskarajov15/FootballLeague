using AutoMapper;
using FootballLeague.Application.Dtos.Team;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Teams.GetAllTeams;

internal class GetAllTeamsQueryHandler : IRequestHandler<GetAllTeamsQuery, IEnumerable<TeamDto>>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public GetAllTeamsQueryHandler(
        ITeamRepository teamRepository,
        IMapper mapper)
    {
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeamDto>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Team> teams = await _teamRepository.GetAllAsync();

        IEnumerable<TeamDto> teamDtos = _mapper.Map<IEnumerable<TeamDto>>(teams);

        return teamDtos;
    }
}
