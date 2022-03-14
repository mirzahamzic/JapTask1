using norm_calc.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using norm_calc.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace norm_calc.Services.IngredientService
{
    public class IngredientService : IIngredientService
    {
        private readonly AppDbContext _context;

        public IngredientService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<GetIngredientsDto>> GetAllIngredients()
        {
            var ingredientsFromDB = await _context.Ingredients.Select(i => new GetIngredientsDto()
            {
                Id = i.Id,
                Name = i.Name,
                UnitQuantity = i.UnitQuantity,
                UnitPrice = i.UnitPrice,
                UnitOfMeasure = i.UnitOfMeasure,
            }).ToListAsync();

            return ingredientsFromDB;
        }
    }
}
