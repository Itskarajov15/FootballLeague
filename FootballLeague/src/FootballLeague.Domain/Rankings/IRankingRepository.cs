namespace FootballLeague.Domain.Rankings;

public interface IRankingRepository
{
    Task<IEnumerable<Ranking>> GetRankingsAsync();
}
