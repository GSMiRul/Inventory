using Application.Common.Interfaces;
using Domain.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        DbSet<T> Table { get; set; }
        public Repository(AppDbContext context)
        {
            Table = context.Set<T>();
        }

        public async Task AddAsync(T entity) =>
            await Table.AddAsync(entity);
        
        public async Task AddAsync(IEnumerable<T> entities) =>
            await Table.AddRangeAsync(entities);
        
        public void Delete(T entity)
        { 
            Table.Remove(entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public async Task<List<T>> GetAllAsync() =>
            await Table.AsNoTracking().ToListAsync();

        public async Task<T> GetByIdAsync(Guid id) => 
            await Table.Where(x=> x.Id == id).FirstOrDefaultAsync();

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = ""
            )
        {
            IQueryable<T> query = Table;
            if(filter != null)
            {
                query = query.Where(filter).AsNoTracking();
            }

            foreach(var includeProp in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }

            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking().ToList();
            }
            else
            {
                return query.AsNoTracking().ToList();
            }
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            Table.UpdateRange(entities);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression) => 
            Table.Where<T>(expression);
    }
}
