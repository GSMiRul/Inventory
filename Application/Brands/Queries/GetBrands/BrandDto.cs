using System;
using AutoMapper;
using Domain.Entities;
using Application.Common.Interfaces.Mappings;

namespace Application.Brands.Queries.GetBrands
{
    public record BrandDto(
        Guid id,
        string brandName,
        string? shortName);
}
