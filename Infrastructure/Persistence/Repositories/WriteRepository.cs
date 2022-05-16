using Application.Common.Interfaces;
using Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteBaseRepository<T> where T : class, IEntity
    {
        private readonly IAppDbContext _applicationDbContext;
        private DbSet<T> _entity;
        public WriteRepository(IAppDbContext appDbContext) : base()
        {
            this._applicationDbContext = appDbContext;
            _entity = _applicationDbContext.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _applicationDbContext.Set<T>().AddAsync(entity, cancellationToken);
            await _applicationDbContext.SaveEntitiesAsync(cancellationToken);
            return entity;
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            T dbEntity = await _entity.FindAsync(id, cancellationToken);
            _entity.Remove(dbEntity);
            await _applicationDbContext.SaveEntitiesAsync(cancellationToken);
        }
        public virtual async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            var entityToRemove = _entity.Find(entity);
            _entity.Remove(entityToRemove);
            await _applicationDbContext.SaveEntitiesAsync(cancellationToken);
        }

        public virtual async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _entity.RemoveRange(entities);
            await _applicationDbContext.SaveEntitiesAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _entity.Update(entity);
            await _applicationDbContext.SaveEntitiesAsync(cancellationToken);
        }
    }
}
