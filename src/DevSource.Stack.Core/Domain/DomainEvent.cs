namespace DevSource.Stack.Core.Domain;

public abstract record DomainEvent : IEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}