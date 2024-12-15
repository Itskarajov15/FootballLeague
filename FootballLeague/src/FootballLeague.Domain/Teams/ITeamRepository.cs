namespace FootballLeague.Domain.Teams;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(Guid id);

    Task<IEnumerable<Team>> GetAllAsync();

    void Add(Team team);

    void Update(Team team);

    void Delete(Team team);
}
