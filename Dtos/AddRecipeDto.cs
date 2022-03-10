using System.Collections.Generic;

namespace norm_calc.Dtos
{
    public class AddRecipeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public int CategoryId { get; set; }
        public List<AddIngredientToRecipeDto> Ingredients { get; set; }

    }

    public class AddIngredientToRecipeDto
    {
        public int IngredientId { get; set; }
        public double IngredientQuantity { get; set; }
        public double IngredientCost { get; set; }
        public string IngredientUnit { get; set; }
    }
}

//public double IngredientCost
//{
//    get
//    {
//        if (IngredientUnit == "gr" || IngredientUnit == "ml")
//        {
//            return IngredientQuantity * (IngredientUnitPrice / 1000);
//        }

//        return IngredientQuantity * IngredientUnitPrice;
//    }
//}
