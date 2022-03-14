using AutoMapper;
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
        private readonly IMapper _mapper;

        public RecipeService(AppDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;

            //used for access to user id from the token and make it available in all methods
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        //getting user id from token
        private int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public void AddRecipe(AddRecipeDto recipe)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == GetUserId());

            var newRecipe = new Recipe()
            {
                Name = recipe.Name,
                Description = recipe.Description,
                //Cost = recipe.Cost,
                CategoryId = recipe.CategoryId,
                CreatedAt = DateTime.Now,
                UserId = user.Id,
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
                    Quantity = ingredient.IngredientQuantity,
                };

                _context.Recipes_Ingredients.Add(recipe_ingredient);
                _context.SaveChanges();
            }

        }

        public async Task<List<GetRecipeDto>> GetAllRecipes(int limit)
        {
            var recipesFromDB = await _context.Recipes.Select(recipe => new GetRecipeDto()

            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,

                //Cost = recipe.Cost,
                CategoryName = recipe.Category.Name,
                Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                {
                    Id = n.IngredientId,
                    IngredientName = n.Ingredient.Name, // ovo je polje iz ingredient tabele
                    IngredientQuantity = n.Quantity, //ovo je polje iz join tabele
                    IngredientUnit = n.Unit, // ovo je polje iz join tabele
                    UnitPrice = n.Ingredient.UnitPrice,//ovo je polje iz ingredient tabele -  cijena sastojka u bazi
                    UnitQuantity = n.Ingredient.UnitQuantity, //ovo je polje iz ingredient tabele - kolicina sastojka u bazi
                }).ToList()

            }).Skip(limit).Take(5).ToListAsync();

            //var recipesFromDB = await _context.Recipes.Include(r => r.Recipes_Ingredients).ToListAsync();

            //var recipes = recipesFromDB.Select(r => _mapper.Map<RecipeToGetDto>(r)).ToList();

            return recipesFromDB;
        }

        public async Task<List<GetRecipeDto>> GetRecipeByCategory(int categoryId)
        {
            var recipesFromDB = await _context.Recipes.Where(n => n.CategoryId == categoryId).Select(recipe => new GetRecipeDto()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,

                //Cost = recipe.Cost,
                CategoryName = recipe.Category.Name,
                Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                {

                    Id = n.IngredientId,
                    IngredientName = n.Ingredient.Name, // ovo je polje iz ingredient tabele
                    IngredientQuantity = n.Quantity, //ovo je polje iz join tabele
                    IngredientUnit = n.Unit, // ovo je polje iz join tabele
                    UnitPrice = n.Ingredient.UnitPrice,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi
                    UnitQuantity = n.Ingredient.UnitQuantity, //ovo je polje iz ingredient tabele - kolicina sastojka u bazi

                }).ToList()

            }).ToListAsync();

            return recipesFromDB;
        }

        public async Task<GetRecipeDto> GetRecipeById(int recipeId)
        {
            var recipeFromDB = await _context.Recipes.Where(n => n.Id == recipeId).Select(recipe => new GetRecipeDto()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,

                //Cost = recipe.Cost,
                CategoryName = recipe.Category.Name,
                Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                {
                    Id = n.IngredientId,
                    IngredientName = n.Ingredient.Name, // ovo je polje iz ingredient tabele
                    IngredientQuantity = n.Quantity, //ovo je polje iz join tabele
                    IngredientUnit = n.Unit, // ovo je polje iz join tabele
                    UnitPrice = n.Ingredient.UnitPrice,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi
                    UnitQuantity = n.Ingredient.UnitQuantity,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi


                }).ToList()

            }).FirstOrDefaultAsync();

            return recipeFromDB;
        }

        public async Task<List<GetRecipeDto>> SearchRecipe(string searchTerm)
        {
            var recipeFromDB = await _context.Recipes
                .Include(r => r.Recipes_Ingredients)
                .Where(n => n.Name.ToLower().Contains(searchTerm) || n.Description.ToLower().Contains(searchTerm))
                .Select(recipe => new GetRecipeDto()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Description = recipe.Description,

                    //Cost = recipe.Cost,
                    CategoryName = recipe.Category.Name,
                    Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                    {
                        Id = n.IngredientId,
                        IngredientName = n.Ingredient.Name, // ovo je polje iz ingredient tabele
                        IngredientQuantity = n.Quantity, //ovo je polje iz join tabele
                        IngredientUnit = n.Unit, // ovo je polje iz join tabele
                        UnitPrice = n.Ingredient.UnitPrice,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi
                        UnitQuantity = n.Ingredient.UnitQuantity,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi


                    }).ToList()
                }
           ).ToListAsync();

            return recipeFromDB;
        }

        public async Task<List<GetRecipeDto>> GetAllRecipesByUserId()
        {
            //in where we can access related table and get user id from there
            var recipesFromDB = await _context.Recipes.Select(recipe => new GetRecipeDto()
            {
                Name = recipe.Name,
                Description = recipe.Description,

                //Cost = recipe.Cost,
                CategoryName = recipe.Category.Name,
                Ingredient = recipe.Recipes_Ingredients.Select(n => new GetIngredientInRecipeDto()
                {
                    Id = n.IngredientId,
                    IngredientName = n.Ingredient.Name, // ovo je polje iz ingredient tabele
                    IngredientQuantity = n.Quantity, //ovo je polje iz join tabele
                    IngredientUnit = n.Unit, // ovo je polje iz join tabele
                    UnitPrice = n.Ingredient.UnitPrice,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi
                    UnitQuantity = n.Ingredient.UnitQuantity,//ovo je polje iz ingredient tabele - jedinicna cijena sastojka u bazi


                }).ToList()
            }
                ).ToListAsync();

            return recipesFromDB;
        }
    }
}
