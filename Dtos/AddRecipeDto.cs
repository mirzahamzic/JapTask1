using norm_calc.Models;
using System.Collections.Generic;

namespace norm_calc.Dtos
{
    public class AddRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<AddIngredientToRecipeDto> Ingredients { get; set; }

    }

    public class AddIngredientToRecipeDto
    {
        public int IngredientId { get; set; }
        public double IngredientQuantity { get; set; }
        public string IngredientUnit { get; set; }
    }
}

