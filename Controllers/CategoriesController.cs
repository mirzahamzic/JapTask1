using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Services;

namespace norm_calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryServices _categoryServices;

        public CategoriesController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [EnableCors("CORS")]
        [HttpGet("get-all-categories")]
        public IActionResult GetAllCategories()
        {
            var allCategories = _categoryServices.GetAllCategories();
            return Ok(allCategories);
        }
    }
}
