using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Tools
{
    public static class MediatorExt
    {
        public static async Task DispatchEventsAsync(this IMediator mediator, AppDbContext context)
        {
            IEnumerable<EntityEntry> domainEntities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents != null && e.Entity.DomainEvents.Any());

            List<INotification> domEvents = domainEntities
                .SelectMany(x => ((BaseEntity)x.Entity).DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(e => ((BaseEntity)e.Entity).CleanDomainEvent());

            foreach (var domainEvent in domEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
