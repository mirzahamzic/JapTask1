using norm_calc.Dtos;
using System.Collections.Generic;

namespace norm_calc.Services.RecipeService
{
    public interface IRecipeService
    {
        public List<GetRecipeDto> GetAllRecipes();
        public GetRecipeDto GetRecipeById(int recipeId);
        public List<GetRecipeDto> GetRecipeByCategory(int categoryId);
        public GetRecipeDto SearchRecipe(string searchTerm);
        public void AddRecipe(AddRecipeDto recipe);

    }
}
