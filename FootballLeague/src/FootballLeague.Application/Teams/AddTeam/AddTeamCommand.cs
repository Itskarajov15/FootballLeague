using MediatR;

namespace FootballLeague.Application.Teams.AddTeam;

public record AddTeamCommand(string Name) : IRequest<Guid>;