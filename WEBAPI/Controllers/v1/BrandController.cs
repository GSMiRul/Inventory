using Application.Brands.Commands.CreateBrand;
using Application.Brands.Commands.DeleteBrand;
using Application.Brands.Commands.UpdateBrand;
using Application.Brands.Queries.GetBrandById;
using Application.Brands.Queries.GetBrands;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.Common;

namespace WEBAPI.v1.Controllers
{
    [ApiVersion("1.0")]
    public class BrandController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateBrandAsync(CreateBrandCommand model)
        {
            return Ok(await Mediator.Send(model));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrandAsync(string id, UpdateBrandCommand model)
        {
            if (id != model.Id.ToString())
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(model));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrandAsync(string id)
        {
            Guid guidValue;

            if (Guid.TryParse(id, out guidValue))
            {
                return Ok(await Mediator.Send(new DeleteBrandCommand() { Id = guidValue }));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBrand(string id)
        {
            Guid guidValue;

            if (Guid.TryParse(id, out guidValue))
            {
                return Ok(await Mediator.Send(new GetBrandByIdQuery() { Id = guidValue }));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetBrands([FromQuery] GetBrandsParameters filter)
        {
            return Ok( await Mediator.Send( new GetBrandsQuery
            (
                filter.Page,
                filter.Size,
                filter.BrandName,
                filter.ShortName
            )));
        }
    }
}
