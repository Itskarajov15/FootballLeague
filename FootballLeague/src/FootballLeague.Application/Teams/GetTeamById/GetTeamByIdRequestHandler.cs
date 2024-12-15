using AutoMapper;
using FootballLeague.Application.Dtos.Team;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Teams.GetTeamById;

internal class GetTeamByIdRequestHandler : IRequestHandler<GetTeamByIdQuery, TeamDto>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMapper _mapper;

    public GetTeamByIdRequestHandler(
        ITeamRepository teamRepository,
        IMapper mapper)
    {
        _teamRepository = teamRepository;
        _mapper = mapper;
    }

    public async Task<TeamDto> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        Team team = await _teamRepository.GetByIdAsync(request.Id);

        TeamDto teamDto = _mapper.Map<TeamDto>(team);

        return teamDto;
    }
}
