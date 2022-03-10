using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Services;

namespace norm_calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientServices _ingredientServices;

        public IngredientsController(IngredientServices ingredientServices)
        {
            _ingredientServices = ingredientServices;
        }

        [EnableCors("CORS")]
        [HttpGet("get-all-ingredients")]
        public IActionResult GetAllRecipes()
        {
            var allIngredients = _ingredientServices.GetAllIngredients();
            return Ok(allIngredients);
        }
    }
}
