namespace FootballLeague.Domain.Shared;

public static class Guard
{
    public static void AgainstEmpty(string value, string parameterName)
    {
        if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} cannot be empty.");
        }
    }

    public static void AgainstNegative(int value, string parameterName)
    {
        if (value < 0)
        {
            throw new ArgumentException($"{parameterName} cannot be negative.");
        }
    }

    public static void AgainstSameTeamIds(Guid team1Id, Guid team2Id)
    {
        if (team1Id == team2Id)
        {
            throw new ArgumentException("Team1Id and Team2Id cannot be the same.");
        }
    }
}
