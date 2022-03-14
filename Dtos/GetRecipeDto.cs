using System.Collections.Generic;
using System.Linq;

namespace norm_calc.Dtos
{
    public class GetRecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost
        {
            get
            {
                return Ingredient.Select(i => i.IngredientCost).Sum();
            }
        }
        public string CategoryName { get; set; }
        public List<GetIngredientInRecipeDto> Ingredient { get; set; }
    }

    public class GetIngredientInRecipeDto
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public double IngredientQuantity { get; set; }
        public double IngredientCost
        {
            get
            {
                return IngredientUnit == "ml" ? (((UnitPrice * IngredientQuantity) / UnitQuantity) / 1000) :
                                     IngredientUnit == "gr" ? (((UnitPrice * IngredientQuantity) / UnitQuantity) / 1000) :
                                     (UnitPrice * IngredientQuantity) / UnitQuantity;
            }
        }
        public string IngredientUnit { get; set; }
        public double UnitPrice { get; set; }
        public double UnitQuantity { get; set; }



    }

    public class GetAllRecipesDto
    {
        public List<GetRecipeDto> GetAllRecipes { get; set; }
    }


}
