using FootballLeague.Domain.Matches;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Infrastructure.Repositories;

internal sealed class MatchRepository : IMatchRepository
{
    private readonly ApplicationDbContext _context;

    public MatchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Match match)
        => _context.Matches.Add(match);

    public void Delete(Match match)
        => _context.Matches.Remove(match);

    public async Task<IEnumerable<Match>> GetAllAsync()
        => await _context.Matches.ToListAsync();

    public async Task<Match?> GetByIdAsync(Guid id)
        => await _context.Matches.FindAsync(id);

    public async Task<IEnumerable<Match>> GetMatchesByTeamIdAsync(Guid teamId)
        => await _context.Matches
            .Where(m => m.Team1Id == teamId || m.Team2Id == teamId)
            .ToListAsync();

    public void Update(Match match)
        => _context.Matches.Update(match);
}
