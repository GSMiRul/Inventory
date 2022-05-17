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
    public class ReadRepository<T> : IReadBaseRepository<T> where T : class
    {
        private readonly IAppDbContext _applicationDbContext;
        private IQueryable<T> _entity;
        public ReadRepository(IAppDbContext appDbContext) : base()
        {
            this._applicationDbContext = appDbContext;
            _entity = _applicationDbContext.Set<T>().AsNoTracking();
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entity.CountAsync(filter, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync(cancellationToken);
            }
            else
            {
                return await query.ToListAsync(cancellationToken);
            }
        }
        public virtual async Task<IEnumerable<T>> GetPagedAsync(
            Expression<Func<T, bool>> filter = null,
            int page = 1,
            int pageSize = 10,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).Skip(page).Take(pageSize).ToListAsync(cancellationToken);
            }
            else
            {
                return await query.Skip(page).Take(pageSize).ToListAsync(cancellationToken);
            }
        }
    }
}
