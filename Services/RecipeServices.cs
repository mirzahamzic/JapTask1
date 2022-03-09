using norm_calc.Data;
using norm_calc.Dtos;
using norm_calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace norm_calc.Services
{
    public class RecipeServices
    {
        private readonly AppDbContext _context;

        public RecipeServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddRecipe(AddRecipeDto recipe)
        {
            var newRecipe = new Recipe()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                Cost = recipe.Cost,
                CategoryId = recipe.CategoryId,
                CreatedAt = DateTime.Now,
            };

            _context.Recipes.Add(newRecipe);
            _context.SaveChanges();


            foreach (var ingredient in recipe.Ingredients)
            {

                var recipe_ingredient = new Recipe_Ingredient()
                {
                    RecipeId = newRecipe.Id,
                    IngredientId = ingredient.IngredientId,
                    Unit = ingredient.IngredientUnit,
                    Price = ingredient.IngredientCost,
                    Quantity = ingredient.IngredientQuantity,

                };

                _context.Recipes_Ingredients.Add(recipe_ingredient);
                _context.SaveChanges();
            }
        }

        public GetRecipeDto GetRecipeById(int recipeId)
        {
            var recipeFromDB = _context.Recipes.Where(n => n.Id == recipeId).Select(recipe => new GetRecipeDto()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                Cost = recipe.Cost,
                CategoryName = recipe.Category.Name,
                Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                {
                    IngredientName = n.Ingredient.Name,
                    IngredientCost = n.Price,
                    IngredientQuantity = n.Quantity,
                    IngredientUnit = n.Unit,
                }).ToList()
            }
            ).FirstOrDefault();

            return recipeFromDB;
        }

        public List<GetRecipeDto> GetAllRecipes()
        {
            var recipesFromDB = _context.Recipes.Select(recipe => new GetRecipeDto()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                Cost = recipe.Cost,
                CategoryName = recipe.Category.Name,
                Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                {
                    IngredientName = n.Ingredient.Name,
                    IngredientCost = n.Price,
                    IngredientQuantity = n.Quantity,
                    IngredientUnit = n.Unit,
                }).ToList()
            }
            ).ToList();

            return recipesFromDB;

        }
    }
}
