using Infrastructure.Persistence.Tools;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using System;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly IMediator _mediator;
        public AppDbContext(DbContextOptions options, IMediator mediator) : base(options) 
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public DbSet<Brand> Brands => Set<Brand>();

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
            var result = await base.SaveChangesAsync(cancellationToken);

            await _mediator.DispatchEventsAsync(this);

            return result;
        }
    }
}
