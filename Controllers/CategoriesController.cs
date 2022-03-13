using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Services;
using norm_calc.Services.CategoryService;
using System.Threading.Tasks;

namespace norm_calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        public CategoriesController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [EnableCors("CORS")]
        [HttpGet("get-all-categories/{limit}")]
        public async Task<IActionResult> GetAllCategories(int limit)
        {
            var allCategories = _categoryServices.GetAllCategories(limit);
            return Ok(await allCategories);
        }
    }
}
