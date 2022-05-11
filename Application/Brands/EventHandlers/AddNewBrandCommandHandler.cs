using Application.Brands.Commands.CreateBrand;
using Application.Common;
using Application.Common.Interfaces;
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
    public class AddNewBrandCommandHandler : IRequestHandler<CreateBrandCommand, RequestResponse<int>>
    {
        private readonly IAppDbContext _context;
        public AddNewBrandCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
        }
       
        async Task<RequestResponse<int>> IRequestHandler<CreateBrandCommand, RequestResponse<int>>.Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                BarandName = request.brandName,
                ShortName = request.shortName,
                Summary = request.summary
            };
            RequestResponse<int> response = new RequestResponse<int>();
            await _context.Brands.AddAsync(brand);
            response.Container = await _context.SaveEntitiesAsync(cancellationToken);

            return response;
        }
    }
}
