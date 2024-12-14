using FootballLeague.Application.Dtos.Team;
using MediatR;

namespace FootballLeague.Application.Teams.GetTeamById;

public record GetTeamByIdQuery(Guid Id) : IRequest<TeamDto>;