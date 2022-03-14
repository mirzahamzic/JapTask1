using norm_calc.Models;

namespace norm_calc.Dtos
{
    public class IngredientToGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; } //from recipe_ingredient
        public double Price
        {
            get
            {
                return UnitOfMeasure == "ml" ? (((UnitPrice * Quantity) / UnitQuantity) / 1000) :
                                     UnitOfMeasure == "gr" ? (UnitPrice * Quantity / 1000) :
                                     (UnitPrice * Quantity) / UnitQuantity;
            }
        }
        public string UnitOfMeasure { get; set; } //from ingredient
        public double UnitPrice { get; set; } //from ingredient
        public double UnitQuantity { get; set; } //from ingredient
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public string Unit { get; set; }
    }
}
