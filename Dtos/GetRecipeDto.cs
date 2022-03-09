using System.Collections.Generic;

namespace norm_calc.Dtos
{
    public class GetRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public string CategoryName { get; set; }
        public List<GetIngredientInRecipeDto> Ingredient { get; set; }
    }

    public class GetIngredientInRecipeDto
    {
        public string IngredientName { get; set; }
        public double IngredientQuantity { get; set; }
        public double IngredientCost { get; set; }
        public string IngredientUnit { get; set; }

    }
}
