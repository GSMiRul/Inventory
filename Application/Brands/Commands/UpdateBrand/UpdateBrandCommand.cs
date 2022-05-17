using Application.Common.RequestResponses;
using MediatR;
using System;

namespace Application.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<RequestResponse<String>>
    {
        public string Id { get; set; }
        public string brandName { get; set; }
        public string? shortName { get; set; }
        public string? summary { get; set; }
    }
}
