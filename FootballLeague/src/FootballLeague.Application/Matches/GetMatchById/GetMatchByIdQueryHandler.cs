﻿using AutoMapper;
using FootballLeague.Application.Common.Exceptions;
using FootballLeague.Application.Dtos.Match;
using FootballLeague.Domain.Matches;
using MediatR;

namespace FootballLeague.Application.Matches.GetMatchById;

internal sealed class GetMatchByIdQueryHandler : IRequestHandler<GetMatchByIdQuery, MatchDto>
{
    private readonly IMatchRepository _matchRepository;
    private readonly IMapper _mapper;

    public GetMatchByIdQueryHandler(
        IMatchRepository matchRepository,
        IMapper mapper)
    {
        _matchRepository = matchRepository;
        _mapper = mapper;
    }

    public async Task<MatchDto> Handle(GetMatchByIdQuery request, CancellationToken cancellationToken)
    {
        Match? match = await _matchRepository.GetByIdAsync(request.Id);

        if (match is null)
        {
            throw new NotFoundException(nameof(Match), request.Id);
        }

        return _mapper.Map<MatchDto>(match);
    }
}
