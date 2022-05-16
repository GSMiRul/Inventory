using Application.Brands.Commands.CreateBrand;
using Application.Common;
using Application.Common.Interfaces;
using Domain.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Brands.EventHandlers.Brands
{
    public class AddNewBrandCommandHandler : IRequestHandler<CreateBrandCommand, RequestResponse<string>>
    {
        private readonly IWriteBaseRepository<Brand> _brandRepository;
        public AddNewBrandCommandHandler(IWriteBaseRepository<Brand> brandRepository, IMediator mediator)
        {
            _brandRepository = brandRepository;
        }
       
        async Task<RequestResponse<string>> IRequestHandler<CreateBrandCommand, RequestResponse<string>>.Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                BarandName = request.brandName,
                ShortName = request.shortName,
                Summary = request.summary
            };
            RequestResponse<string> response = new RequestResponse<string>();
            
            Brand resp = await _brandRepository.AddAsync(brand);
            response.Container = resp.Id != default ? resp.Id.ToString() : "";

            return response;
        }
    }
}
