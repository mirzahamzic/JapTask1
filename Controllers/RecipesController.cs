using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Data;
using norm_calc.Dtos;
using norm_calc.Services;
using norm_calc.Services.RecipeService;

namespace norm_calc.Controllers
{
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
        public IActionResult AddBook([FromBody] AddRecipeDto recipe)
        {
            _recipeService.AddRecipe(recipe);
            return Ok(recipe);
        }

        [HttpGet("get-recipe-by-id/{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeService.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpGet("get-all-recipes")]
        public IActionResult GetAllRecipes()
        {
            var allRecipes = _recipeService.GetAllRecipes();
            return Ok(allRecipes);
        }

        [HttpGet("get-recipes-by-category/{id}")]
        public IActionResult GetAllRecipesByCategory(int id)
        {
            var allRecipes = _recipeService.GetRecipeByCategory(id);
            return Ok(allRecipes);
        }

        [HttpGet("get-recipes-by-search-term/{searchTerm}")]
        public IActionResult SearchRecipe(string searchTerm)
        {
            var allRecipes = _recipeService.SearchRecipe(searchTerm);
            return Ok(allRecipes);
        }

    }
}
