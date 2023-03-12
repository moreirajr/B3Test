using B3Test.Domain.SeedWork;
using B3Test.Infrastructure.Persistence;
using MediatR;

namespace B3Test.Infrastructure.Extensions
{
    internal static class MediatorExtensions
    {
        internal static async Task DispatchDomainEventsAsync(this IMediator mediator, B3TestContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<AEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
