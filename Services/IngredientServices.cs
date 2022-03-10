using norm_calc.Data;
using norm_calc.Dtos;
using norm_calc.Models;
using System.Collections.Generic;
using System.Linq;

namespace norm_calc.Services
{
    public class IngredientServices
    {
        private readonly AppDbContext _context;

        public IngredientServices(AppDbContext context)
        {
            _context = context;
        }

        public List<GetIngredientsDto> GetAllIngredients()
        {
            var ingredientsFromDB = _context.Ingredients.Select(i => new GetIngredientsDto()
            {
                Id = i.Id,
                Name = i.Name,
                UnitQuantity = i.UnitQuantity,
                UnitPrice = i.UnitPrice,
                UnitOfMeasure = i.UnitOfMeasure,
            }).ToList();

            return ingredientsFromDB;

        }
    }
}
