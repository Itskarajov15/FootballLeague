using AutoMapper;
using FootballLeague.Application.Dtos.Match;
using FootballLeague.Application.Dtos.Team;
using FootballLeague.Domain.Teams;
using System.Text.RegularExpressions;

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
