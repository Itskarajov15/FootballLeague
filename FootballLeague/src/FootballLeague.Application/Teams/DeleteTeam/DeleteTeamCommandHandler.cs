using FootballLeague.Application.Common.Exceptions;
using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Teams.DeleteTeam;

internal class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTeamCommandHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        Team team = await _teamRepository.GetTeamByIdAsync(request.Id);

        if (team is null)
        {
            throw new NotFoundException(nameof(Team), request.Id);
        }

        _teamRepository.DeleteTeam(team);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
