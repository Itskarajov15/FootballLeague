using MediatR;

namespace FootballLeague.Application.Teams.DeleteTeam;

public record DeleteTeamCommand(Guid Id) : IRequest;