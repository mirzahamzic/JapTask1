using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using norm_calc.Data;
using norm_calc.Dtos;
using norm_calc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace norm_calc.Services.RecipeService
{
    public class RecipeService : IRecipeService
    {
        private readonly AppDbContext _context;

        //used for access to user id from the token and make it available in all methods
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RecipeService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;

            //used for access to user id from the token and make it available in all methods
            _httpContextAccessor = httpContextAccessor;
        }

        //getting user id from token
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

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
                    RecipeId = newRecipe.Id, //geting id after recipe is saved to DB
                    IngredientId = ingredient.IngredientId,
                    Unit = ingredient.IngredientUnit,
                    Price = ingredient.IngredientCost,
                    Quantity = ingredient.IngredientQuantity,


                };

                _context.Recipes_Ingredients.Add(recipe_ingredient);
                _context.SaveChangesAsync();
            }

        }

        public async Task<List<GetRecipeDto>> GetAllRecipes()
        {
            var recipesFromDB = await _context.Recipes.Select(recipe => new GetRecipeDto()
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
                        ).ToListAsync();

            return recipesFromDB;
        }

        public async Task<List<GetRecipeDto>> GetRecipeByCategory(int categoryId)
        {
            var recipesFromDB = await _context.Recipes.Where(n => n.CategoryId == categoryId).Select(recipe => new GetRecipeDto()
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
            ).ToListAsync();

            return recipesFromDB;
        }

        public async Task<GetRecipeDto> GetRecipeById(int recipeId)
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

        public async Task<List<GetRecipeDto>> SearchRecipe(string searchTerm)
        {
            var recipeFromDB = _context.Recipes.Where(n => n.Name.ToLower().Contains(searchTerm) || n.Description.ToLower().Contains(searchTerm)).Select(recipe => new GetRecipeDto()
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

            return recipeFromDB;
        }

        public async Task<List<GetRecipeDto>> GetAllRecipesByUserId()
        {
            //in where we can access related table and get user id from there
            var recipesFromDB = await _context.Recipes.Where(r => r.User.Id == GetUserId()).Select(recipe => new GetRecipeDto()
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
                ).ToListAsync();

            return recipesFromDB;
        }
    }
}
