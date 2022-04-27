using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI.Controllers
{
    public class BrandController : Controller
    {
        private readonly UnitOfWork<Brand> _unitOfWork;
        public BrandController(UnitOfWork<Brand> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            IReadOnlyList<Brand> brands = await _unitOfWork.Repository.GetAllAsync();
            await _unitOfWork.Commit();
            return Ok(brands);
        }
    }
}
