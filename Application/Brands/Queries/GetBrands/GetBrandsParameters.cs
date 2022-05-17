using Application.Common.RequestResponses;

namespace Application.Brands.Queries.GetBrands
{
    public class GetBrandsParameters : PagedResponseConfig
    {
        public string BrandName { get; set; }
        public string ShortName { get; set; }
    }
}
