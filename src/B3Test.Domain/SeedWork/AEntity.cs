using MediatR;

namespace B3Test.Domain.SeedWork
{
    public abstract class AEntity
    {
        private List<INotification> _domainEvents = new();
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }

    public abstract class AEntity<T> : AEntity
    {
        public T Id { get; init; } = default(T)!;
    }
}
