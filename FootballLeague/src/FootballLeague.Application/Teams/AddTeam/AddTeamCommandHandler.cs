using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Teams.AddTeam;

internal sealed class AddTeamCommandHandler : IRequestHandler<AddTeamCommand, Guid>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddTeamCommandHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(AddTeamCommand request, CancellationToken cancellationToken)
    {
        Team team = Team.Create(request.Name);

        _teamRepository.Add(team);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return team.Id;
    }
}
