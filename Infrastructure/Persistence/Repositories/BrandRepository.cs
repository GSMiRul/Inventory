using Application.Common.Interfaces;
using Application.Common.Interfaces.Brands;
using Domain.Entities;

namespace Infrastructure.Persistence.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
