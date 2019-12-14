using MediatR;
using NPD.Domain.Common;
using NPD.Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;

namespace NPD.Infrastructure.Extensions
{
    static class MediatorExtensions
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, NPDContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<AggregateRoot>() //BaseEntity
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
