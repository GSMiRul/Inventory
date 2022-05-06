using Application.Brands.Commands.CreateBrand;
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
    public class AddNewBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
    {
        private readonly IAppDbContext _context;
        public AddNewBrandCommandHandler(IAppDbContext context, IMediator mediator)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Id = request.id,
                BarandName = request.brandName,
                ShortName = request.shortName
            };

            await _context.Brands.AddAsync(brand);

            return await _context.SaveEntitiesAsync(cancellationToken);
        }
    }
}
