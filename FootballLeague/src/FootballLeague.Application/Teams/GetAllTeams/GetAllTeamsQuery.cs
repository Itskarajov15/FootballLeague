using FootballLeague.Application.Dtos.Team;
using MediatR;

namespace FootballLeague.Application.Teams.GetAllTeams;

public record GetAllTeamsQuery() : IRequest<IEnumerable<TeamDto>>;
