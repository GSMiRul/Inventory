using Application.Common.RequestResponses;
using MediatR;
using System;

namespace Application.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest<RequestResponse<String>>
    {
        public Guid Id { get; set; }
        public string brandName { get; set; }
        public string? shortName { get; set; }
        public string? summary { get; set; }
    }
}
