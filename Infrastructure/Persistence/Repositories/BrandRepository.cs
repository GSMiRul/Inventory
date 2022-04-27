using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
