using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Common.Interfaces
{
    public interface IReadBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            CancellationToken cancellationToken = default
            );
        Task<IEnumerable<T>> GetPagedAsync(
            Expression<Func<T, bool>> filter = null,
            int page = 1,
            int pageSize = 10,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "",
            CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    }
}
