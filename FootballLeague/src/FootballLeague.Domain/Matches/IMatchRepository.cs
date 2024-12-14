namespace FootballLeague.Domain.Matches;

public interface IMatchRepository
{
    Task<Match> GetMatchByIdAsync(Guid id);

    Task<IEnumerable<Match>> GetAllMatchesAsync();

    void AddMatch(Match match);

    void UpdateMatch(Match match);

    void DeleteMatch(Match match);
}
