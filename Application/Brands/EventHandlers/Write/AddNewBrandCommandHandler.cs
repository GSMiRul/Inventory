using Application.Brands.Commands.CreateBrand;
using Application.Common.Mappings;
using Application.Common.RequestResponses;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Brands.EventHandlers.Write
{
    public class AddNewBrandCommandHandler : IRequestHandler<CreateBrandCommand, RequestResponse<string>>
    {
        private readonly IWriteBaseRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public AddNewBrandCommandHandler(IWriteBaseRepository<Brand> brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
       
        async Task<RequestResponse<string>> IRequestHandler<CreateBrandCommand, RequestResponse<string>>.Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand newRecord = new MappProfile<CreateBrandCommand, Brand>(_mapper, request).MapResponse;
            Brand resp = await _brandRepository.AddAsync(newRecord);

            return new RequestResponse<string>(resp.Id.ToString());
        }
    }
}
