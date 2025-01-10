namespace BankProducts.Domain.Aggregates;


public abstract class Aggregate<T>(T id, DateTime createdOn, DateTime lastModifiedOn) where T : struct
{
    private readonly IList<IDomainEvent> _domainEvents = [];

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return [.. _domainEvents];
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public T Id { get; private set; } = id;
    public DateTime CreatedOn { get; private set; } = createdOn;
    public DateTime LastModifiedOn { get; private set; } = lastModifiedOn;
}
