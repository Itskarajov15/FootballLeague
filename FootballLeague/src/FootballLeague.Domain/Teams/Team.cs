using FootballLeague.Domain.Abstractions;
using FootballLeague.Domain.Shared;

namespace FootballLeague.Domain.Teams;

public sealed class Team : Entity
{
    private Team(
        Guid id,
        string name)
        : base(id)
    {
        Name = name;
    }

    private Team()
    {
    }

    public string Name { get; private set; }

    public int MatchesPlayed { get; private set; }

    public int Wins { get; private set; }

    public int Draws { get; private set; }

    public int Losses { get; private set; }

    public static Team Create(string name)
    {
        Guard.AgainstEmpty(name, nameof(Name));

        return new Team(Guid.NewGuid(), name);
    }

    public void UpdateStatistics(int points)
    {
        MatchesPlayed++;

        switch (points)
        {
            case 3:
                Wins++;
                break;
            case 1:
                Draws++;
                break;
            case 0:
                Losses++;
                break;
        }
    }
}
