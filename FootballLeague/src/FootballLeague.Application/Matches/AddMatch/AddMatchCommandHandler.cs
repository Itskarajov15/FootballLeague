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
        Team team1 = await _teamRepository.GetTeamByIdAsync(request.Team1Id);

        if (team1 is null)
        {
            throw new NotFoundException(nameof(Team), request.Team1Id);
        }

        Team team2 = await _teamRepository.GetTeamByIdAsync(request.Team2Id);

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

        (int team1Points, int team2Points) = _matchScoreService.CalculatePoints(match.Team1Score, match.Team2Score);

        team1.UpdateStatistics(team1Points);
        team2.UpdateStatistics(team2Points);

        _matchRepository.AddMatch(match);
        _teamRepository.UpdateTeam(team1);
        _teamRepository.UpdateTeam(team2);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return match.Id;
    }
}
