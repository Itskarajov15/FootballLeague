using FootballLeague.Domain.Teams;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Infrastructure.Repositories;

internal sealed class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Team team)
        => _context.Teams.Add(team);

    public void Delete(Team team)
        => _context.Teams.Remove(team);

    public async Task<IEnumerable<Team>> GetAllAsync()
        => await _context.Teams.ToListAsync();

    public async Task<Team?> GetByIdAsync(Guid id)
        => await _context.Teams.FindAsync(id);

    public void Update(Team team)
        => _context.Teams.Update(team);
}
