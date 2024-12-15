using AutoMapper;
using FootballLeague.Application.Dtos.Match;
using FootballLeague.Application.Dtos.Team;
using FootballLeague.Domain.Matches;
using FootballLeague.Domain.Teams;

namespace FootballLeague.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Teams
        CreateMap<Team, TeamDto>();

        //Matches
        CreateMap<Match, MatchDto>();
    }
}
