using MediatR;
using System;
using System.Windows.Input;

namespace Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<int>
    {
        public Guid id { get; set; }
        public string brandName { get; set; }
        public string? shortName { get; set; }
    }
}
