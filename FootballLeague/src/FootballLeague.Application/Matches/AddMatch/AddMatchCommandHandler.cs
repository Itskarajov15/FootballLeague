﻿using FootballLeague.Application.Common.Exceptions;
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
        var results = await Task.WhenAll(new[]
        {
            _teamRepository.GetByIdAsync(request.Team1Id),
            _teamRepository.GetByIdAsync(request.Team2Id)
        });

        if (results[0] is null || results[1] is null)
        {
            throw new NotFoundException(nameof(Team), results[0] is null ? request.Team1Id : request.Team2Id);
        }

        Match match = Match.Create(
            request.Team1Id,
            request.Team2Id,
            request.Team1Score,
            request.Team2Score,
            request.MatchDate);

        _matchScoreService.AddPointsToTeams(match, results[0], results[1]);

        _matchRepository.Add(match);
        _teamRepository.Update(results[0]);
        _teamRepository.Update(results[1]);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return match.Id;
    }
}
