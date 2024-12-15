using FootballLeague.Domain.Rankings;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Infrastructure.Repositories;

internal sealed class RankingRepository : IRankingRepository
{
    private readonly ApplicationDbContext _context;

    public RankingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ranking>> GetRankingsAsync()
        => await _context
        .Teams
        .Select(t => new Ranking
        {
            TeamName = t.Name,
            Wins = t.Wins,
            Draws = t.Draws,
            Losses = t.Losses,
            MatchesPlayed = t.MatchesPlayed,
            Points = t.Wins * 3 + t.Draws,
            GoalsScored = _context.Matches
                .Where(m => m.Team1Id == t.Id)
                .Sum(m => m.Team1Score) +
                _context.Matches
                .Where(m => m.Team2Id == t.Id)
                .Sum(m => m.Team2Score)
        })
        .ToListAsync();
}
