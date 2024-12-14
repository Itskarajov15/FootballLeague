namespace FootballLeague.Domain.Teams;

public interface ITeamRepository
{
    Task<Team> GetTeamByIdAsync(Guid id);

    Task<IEnumerable<Team>> GetAllTeamsAsync();

    void AddTeam(Team team);

    void UpdateTeam(Team team);

    void DeleteTeam(Team team);
}
