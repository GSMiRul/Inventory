using Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
