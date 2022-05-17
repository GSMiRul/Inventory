using Application.Brands.Queries.DTO;
using Application.Brands.Queries.GetBrands;
using Application.Common.Mappings;
using Application.Common.RequestResponses;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Brands.EventHandlers.Read
{
    public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, PagedResponse<List<BrandDto>>>
    {
        private readonly IReadBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public GetBrandsQueryHandler(IReadBaseRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<BrandDto>>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Brand> brands;

            if (!string.IsNullOrEmpty(request.BrandName))
            {
                if (!string.IsNullOrEmpty(request.ShortName))
                {
                    brands = await _brandRepository.GetPagedAsync(
                    b => b.BarandName.Contains(request.BrandName) &&
                    b.ShortName.Contains(request.ShortName),
                    request.Page, request.PageSize);
                }
                else
                {
                    brands = await _brandRepository.GetPagedAsync(
                        b => b.BarandName.Contains(request.BrandName),
                        request.Page, request.PageSize);
                }
            }
            else
            {
                brands = await _brandRepository.GetPagedAsync(null,
                        request.Page, request.PageSize);
            }

            List<BrandDto> brandsDto = new MappProfile<List<Brand>, List<BrandDto>>(_mapper, brands.ToList()).MapResponse;

            return new PagedResponse<List<BrandDto>>(brandsDto, request.Page, request.PageSize);
        }
    }
}
