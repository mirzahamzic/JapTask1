using norm_calc.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace norm_calc.Services.RecipeService
{
    public interface IRecipeService
    {
        public Task<List<GetRecipeDto>> GetAllRecipes();
        public Task<GetRecipeDto> GetRecipeById(int recipeId);
        public Task<List<GetRecipeDto>> GetRecipeByCategory(int categoryId);
        public Task<List<GetRecipeDto>> SearchRecipe(string searchTerm);
        public void AddRecipe(AddRecipeDto recipe);

    }
}
