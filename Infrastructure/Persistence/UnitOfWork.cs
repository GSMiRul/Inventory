using Application.Common.Interfaces;
using Domain.Common.Interfaces;
using Infrastructure.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;
        private bool disposed = false;
        public IRepository<T> Repository { get; }
        
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
            if (this.Repository == null)
            {
                this.Repository = new Repository<T>(_context);
            }
        }
        public async Task Commit() =>
            await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}
