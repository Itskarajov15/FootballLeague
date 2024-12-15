namespace FootballLeague.Domain.Matches;

public interface IMatchRepository
{
    Task<Match> GetByIdAsync(Guid id);

    Task<IEnumerable<Match>> GetAllAsync();

    Task<IEnumerable<Match>> GetMatchesByTeamIdAsync(Guid teamId);

    void Add(Match match);

    void Update(Match match);

    void Delete(Match match);
}
