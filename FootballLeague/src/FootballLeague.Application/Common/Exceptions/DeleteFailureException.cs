namespace FootballLeague.Application.Common.Exceptions;

public class DeleteFailureException : Exception
{
    public DeleteFailureException(string name, object key)
        : base($"Deletion of entity \"{name}\" ({key}) failed.")
    {
    }
}
