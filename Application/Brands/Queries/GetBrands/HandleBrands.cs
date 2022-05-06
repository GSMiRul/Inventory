using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Brands.Queries.GetBrands
{
    public class HandleBrands : IQueryHandler<GetBrandsQuery, IReadOnlyList<BrandDto>>
    {
        private readonly IQueryable<Brand> _brands;
        public HandleBrands(IQueryable<Brand> brands)
        {
            this._brands = brands;
        }
        public async ValueTask<IReadOnlyList<BrandDto>> Handle(GetBrandsQuery query)
        {
            var (filter, page, pageSize) = query;

            var filteredBrands = string.IsNullOrEmpty(filter)
                ? _brands
                : _brands
                    .Where(b =>
                        b.Id.Equals(query.Filter!) ||
                        b.BarandName.Contains(query.Filter!) ||
                        b.ShortName!.Contains(query.Filter!)
                    );

            return await filteredBrands
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .Select(b => new BrandDto(b.Id, b.BarandName, b.ShortName))
                .ToListAsync();
        }
    }
}
