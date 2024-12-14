namespace FootballLeague.Domain.Abstractions;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
    }

    protected Entity()
    {
    }

    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
}
