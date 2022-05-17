using System;

namespace Application.Brands.Queries.DTO
{    
    public record BrandDto(
        Guid id,
        string brandName,
        string? shortName);    
}
