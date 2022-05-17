using Application.Brands.Queries.DTO;
using Application.Common.RequestResponses;
using MediatR;
using System.Collections.Generic;

namespace Application.Brands.Queries.GetBrands
{
    public record GetBrandsQuery(int Page, int PageSize, string BrandName, string ShortName) : IRequest<PagedResponse<List<BrandDto>>>
    { 
    }
}
