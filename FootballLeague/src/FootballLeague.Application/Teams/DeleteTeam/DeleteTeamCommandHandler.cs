using FootballLeague.Application.Common.Exceptions;
using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Matches;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Teams.DeleteTeam;

internal class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IMatchRepository _matchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTeamCommandHandler(
        ITeamRepository teamRepository,
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _matchRepository = matchRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        Team? team = await _teamRepository.GetByIdAsync(request.Id);

        if (team is null)
        {
            throw new NotFoundException(nameof(Team), request.Id);
        }

        IEnumerable<Match> matches = await _matchRepository.GetMatchesByTeamIdAsync(request.Id);

        if (matches.Any())
        {
            throw new DeleteFailureException(nameof(Team), request.Id);
        }

        _teamRepository.Delete(team);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
