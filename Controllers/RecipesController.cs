using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using norm_calc.Data;
using norm_calc.Dtos;
using norm_calc.Services;

namespace norm_calc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        public RecipeServices _recipeServices;

        public RecipesController(RecipeServices recipeServices)
        {
            _recipeServices = recipeServices;
        }

        [HttpPost("add-recipe-ingredient")]
        public IActionResult AddBook([FromBody] AddRecipeDto recipe)
        {
            _recipeServices.AddRecipe(recipe);
            return Ok(recipe);
        }

        [HttpGet("get-recipe-by-id/{id}")]
        public IActionResult GetRecipeById(int id)
        {
            var recipe = _recipeServices.GetRecipeById(id);
            return Ok(recipe);
        }

        [HttpGet("get-all-recipes")]
        public IActionResult GetAllRecipes()
        {
            var allRecipes = _recipeServices.GetAllRecipes();
            return Ok(allRecipes);
        }

    }
}
