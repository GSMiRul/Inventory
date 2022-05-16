using Application.Common;
using MediatR;
using System;
using System.Windows.Input;

namespace Application.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<RequestResponse<string>>
    {
        public string brandName { get; set; }
        public string? shortName { get; set; }
        public string? summary { get; set; }
    }
}
