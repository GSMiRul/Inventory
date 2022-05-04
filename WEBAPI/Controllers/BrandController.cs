using Application.Brands.Commands.CreateBrand;
using Application.Common.Interfaces.Brands;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Application.Brands.Commands.UpdateBrand;
using Application.Brands.Commands.DeleteBrand;
using Application.Common.Interfaces;
using Application.Brands.Queries.GetBrands;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private ICommandHandler<CreateBrandCommand> _createCommandHandler { get; init; }
        private ICommandHandler<UpdateBrandCommand> _updateCommandHandler { get; init; }
        private ICommandHandler<DeleteBrandCommand> _deleteCommandHandler { get; init; }
        public BrandController(
            ICommandHandler<CreateBrandCommand> createBrandHandler,
            ICommandHandler<UpdateBrandCommand> updateCommandHandler,
            ICommandHandler<DeleteBrandCommand> deleteCommandHandler
            )
        {
            _createCommandHandler = createBrandHandler;
            _updateCommandHandler = updateCommandHandler;
            _deleteCommandHandler = deleteCommandHandler;
        }

        [HttpPost]
        public ActionResult CreateBrand(CreateBrandCommand model)
        {
            _createCommandHandler.Handle(model);
            return Ok();
        }
        [HttpPut]
        public ActionResult UpdateBrand(UpdateBrandCommand model)
        {
            _updateCommandHandler.Handle(model);
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
            return await getBrandById(GetBrandsQuery.With(brandId))
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
