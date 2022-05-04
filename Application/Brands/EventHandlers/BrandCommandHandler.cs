using Application.Brands.Commands.CreateBrand;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Brands;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Brands.EventHandlers
{
    public class BrandCommandHandler :
        ICommandHandler<CreateBrandCommand>
    {
        private IRepository<Brand> _brandRepository { get; init; }

        public BrandCommandHandler(IRepository<Brand> repository) 
        { 
            _brandRepository = repository; 
        }

        public void Handle(CreateBrandCommand command)
        {
            _brandRepository.AddAsync(command);
        }
    }
}
