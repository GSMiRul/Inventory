using Infrastructure.Persistence.Tools;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;
using Domain.Common;
using Domain.Common.Interfaces;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        //private readonly IMediator _mediator;
        private readonly IDateTimeService _dateTimeService;
        public AppDbContext(DbContextOptions<AppDbContext> options, IDateTimeService dateTimeService) : base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _dateTimeService = dateTimeService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.AddPirmaryKeys();
            modelBuilder.AddIndex();
            modelBuilder.AddSeedData();

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.Updated = _dateTimeService.NowUtc;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = _dateTimeService.NowUtc;
                        break;
                    default:
                        break;
                }
            }
            var result = await base.SaveChangesAsync(cancellationToken);

            //await _mediator.DispatchEventsAsync(this);

            return result;
        }
    }
}
