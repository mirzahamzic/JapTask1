using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Services;
using norm_calc.Services.IngredientService;
using System.Threading.Tasks;

namespace norm_calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientServices;

        public IngredientsController(IIngredientService ingredientServices)
        {
            _ingredientServices = ingredientServices;
        }

        [EnableCors("CORS")]
        [HttpGet("get-all-ingredients")]
        public async Task<IActionResult> GetAllRecipes()
        {
            var allIngredients = _ingredientServices.GetAllIngredients();
            return Ok(await allIngredients);
        }
    }
}
