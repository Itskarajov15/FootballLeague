using FootballLeague.Application.Common.Exceptions;
using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Matches;
using FootballLeague.Domain.Teams;
using MediatR;

namespace FootballLeague.Application.Matches.AddMatch;

internal sealed class AddMatchCommandHandler : IRequestHandler<AddMatchCommand, Guid>
{
    private readonly IMatchRepository _matchRepository;
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly MatchScoreService _matchScoreService;

    public AddMatchCommandHandler(
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

    public async Task<Guid> Handle(AddMatchCommand request, CancellationToken cancellationToken)
    {
        Team? team1 = await _teamRepository.GetByIdAsync(request.Team1Id);

        if (team1 is null)
        {
            throw new NotFoundException(nameof(Team), request.Team1Id);
        }

        Team? team2 = await _teamRepository.GetByIdAsync(request.Team2Id);

        if (team2 is null)
        {
            throw new NotFoundException(nameof(Team), request.Team2Id);
        }

        Match match = Match.Create(
            request.Team1Id,
            request.Team2Id,
            request.Team1Score,
            request.Team2Score,
            request.MatchDate);

        _matchScoreService.AddPointsToTeams(match, team1, team2);

        _matchRepository.Add(match);
        _teamRepository.Update(team1);
        _teamRepository.Update(team2);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return match.Id;
    }
}
