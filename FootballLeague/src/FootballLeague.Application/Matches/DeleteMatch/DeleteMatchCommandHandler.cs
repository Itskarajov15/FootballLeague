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

        var results = await Task.WhenAll(new[]
        {
            _teamRepository.GetByIdAsync(match.Team1Id),
            _teamRepository.GetByIdAsync(match.Team2Id)
        });

        if (results[0] is null || results[1] is null)
        {
            throw new NotFoundException(nameof(Team), results[0] is null ? match.Team1Id : match.Team2Id);
        }

        _matchScoreService.RemovePointsFromTeams(match, results[0], results[1]);

        _teamRepository.Update(results[0]);
        _teamRepository.Update(results[1]);
        _matchRepository.Delete(match);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
