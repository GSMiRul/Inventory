using Application.Brands.Queries.DTO;
using Application.Common.RequestResponses;
using MediatR;
using System;

namespace Application.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<RequestResponse<BrandDto>>
    {
        public Guid Id { get; set; }
    }
}
