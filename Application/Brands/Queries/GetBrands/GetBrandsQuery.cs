using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.Queries.GetBrands
{
    public record GetBrandsQuery(string? Filter, int Page, int Size)
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;
        public static GetBrandsQuery With(string? filter, int? page = null, int? size = null)
        {
            page ??= DefaultPage;
            size ??= DefaultPageSize;

            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            return new(filter, page.Value, size.Value);
        }
    }
}
