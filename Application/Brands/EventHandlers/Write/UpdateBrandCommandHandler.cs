using Application.Brands.Commands.UpdateBrand;
using Application.Common.Mappings;
using Application.Common.RequestResponses;
using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Brands.EventHandlers.Write
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, RequestResponse<string>>
    {
        private readonly IWriteBaseRepository<Brand> _brandRepository;
        private readonly IReadBaseRepository<Brand> _brandReadRepository;
        private readonly IMapper _mapper;
        public UpdateBrandCommandHandler(IWriteBaseRepository<Brand> brandRepository, IReadBaseRepository<Brand> brandReadRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _brandReadRepository = brandReadRepository;
            _mapper = mapper;
        }

        async Task<RequestResponse<string>> IRequestHandler<UpdateBrandCommand, RequestResponse<string>>.Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            int record = await _brandReadRepository.CountAsync(b => b.Id.ToString() == request.Id);

            if (record == 0)
            {
                throw new KeyNotFoundException($"Unable to update the request with the id {request.Id.ToString()}, because it doesn't exists.");
            }
            else
            {
                Brand newRecord = new MappProfile<UpdateBrandCommand, Brand>(_mapper, request).MapResponse;

                await _brandRepository.UpdateAsync(newRecord);

                return new RequestResponse<string>(newRecord.Id.ToString());
            }            
        }
    }
}
