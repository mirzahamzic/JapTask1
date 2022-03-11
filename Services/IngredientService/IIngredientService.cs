using norm_calc.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace norm_calc.Services.IngredientService
{
    public interface IIngredientService
    {
        public Task<List<GetIngredientsDto>> GetAllIngredients();
    }
}
