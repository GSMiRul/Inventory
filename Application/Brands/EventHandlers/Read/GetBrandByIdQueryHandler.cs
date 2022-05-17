using Application.Brands.Queries.DTO;
using Application.Brands.Queries.GetBrandById;
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
    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery,RequestResponse<BrandDto>>
    {
        private readonly IReadBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public GetBrandByIdQueryHandler(IReadBaseRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<RequestResponse<BrandDto>> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
            if (brand == null)
            {
                throw new KeyNotFoundException($"Record doesn't exists");
            }
            else
            {
                var dto = new MappProfile<Brand, BrandDto>(_mapper, brand.FirstOrDefault()).MapResponse;
                return new RequestResponse<BrandDto>(dto);
            }
        }
    }
}
