using Application.Brands.Commands.CreateBrand;
using Application.Common.Interfaces.Brands;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Application.Brands.Commands.UpdateBrand;
using Application.Brands.Commands.DeleteBrand;
using Application.Common.Interfaces;
using Application.Brands.Queries.GetBrands;
using MediatR;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public ActionResult CreateBrand(CreateBrandCommand model)
        {
            _mediator.Send(model);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateBrand(UpdateBrandCommand model)
        {
            _mediator.Send(model);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteBrand(DeleteBrandCommand model)
        {
            _deleteCommandHandler.Handle(model);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetBrand(
            [FromServices] IQueryHandler<GetBrandsQuery, BrandDto?> getBrandById,
            Guid brandId)
        {
            return await getBrandById(GetBrandsQuery.With(brandId.ToString()))
                is { } brand
                ? Results.Ok(brand)
                : Results.NotFound();
        }
        [HttpGet]
        public ActionResult GetBrands()
        {
            _deleteCommandHandler.Handle(model);
            return Ok();
        }
    }
}
