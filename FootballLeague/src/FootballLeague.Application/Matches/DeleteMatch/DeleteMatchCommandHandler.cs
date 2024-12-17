using FootballLeague.Application.Common.Exceptions;
using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Matches;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Matches.DeleteMatch;

internal sealed class DeleteMatchCommandHandler : IRequestHandler<DeleteMatchCommand>
{
    private readonly IMatchRepository _matchRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly MatchScoreService _matchScoreService;

    public DeleteMatchCommandHandler(
        IMatchRepository matchRepository,
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork,
        MatchScoreService matchScoreService)
    {
        _matchRepository = matchRepository;
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
        _matchScoreService = matchScoreService;
    }

    public async Task Handle(DeleteMatchCommand request, CancellationToken cancellationToken)
    {
        var match = await _matchRepository.GetByIdAsync(request.MatchId);

        if (match is null)
        {
            throw new NotFoundException(nameof(Match), request.MatchId);
        }

        Team? team1 = await _teamRepository.GetByIdAsync(match.Team1Id);

        if (team1 is null)
        {
            throw new NotFoundException(nameof(Team), match.Team1Id);
        }

        Team? team2 = await _teamRepository.GetByIdAsync(match.Team2Id);

        if (team2 is null)
        {
            throw new NotFoundException(nameof(Team), match.Team2Id);
        }

        _matchScoreService.RemovePointsFromTeams(match, team1, team2);

        _teamRepository.Update(team1);
        _teamRepository.Update(team2);
        _matchRepository.Delete(match);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
