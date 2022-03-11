using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Data;
using norm_calc.Dtos;
using norm_calc.Services.RecipeService;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace norm_calc.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeServices)
        {
            _recipeService = recipeServices;
        }

        [EnableCors("CORS")]
        [HttpPost("add-recipe-ingredient")]
        public IActionResult AddRecipe([FromBody] AddRecipeDto recipe)
        {
            _recipeService.AddRecipe(recipe);
            return Ok(recipe);
        }

        [HttpGet("get-recipe-by-id/{id}")]
        public async Task<IActionResult> GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return Ok(await recipe);
        }

        [HttpGet("get-all-recipes")]
        public async Task<IActionResult> GetAllRecipes()
        {
            //user claims from token
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var allRecipes = _recipeService.GetAllRecipes();
            return Ok(await allRecipes);
        }

        [HttpGet("get-recipes-by-category/{id}")]
        public async Task<IActionResult> GetAllRecipesByCategory(int id)
        {
            var allRecipes = _recipeService.GetRecipeByCategory(id);
            return Ok(await allRecipes);
        }

        [HttpGet("get-recipes-by-search-term/{searchTerm}")]
        public async Task<IActionResult> SearchRecipe(string searchTerm)
        {
            var allRecipes = _recipeService.SearchRecipe(searchTerm);
            return Ok(await allRecipes);
        }

        [HttpGet("get-all-recipes-by-user")]
        public async Task<IActionResult> GetAllRecipesByUserId()
        {
            //user claims from token
            //int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var allRecipes = _recipeService.GetAllRecipesByUserId();
            return Ok(await allRecipes);
        }

    }
}
