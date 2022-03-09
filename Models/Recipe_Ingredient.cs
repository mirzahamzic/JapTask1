namespace norm_calc.Models
{
    public class Recipe_Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public double Quantity { get; set; }
        public string Unit { get; set; }
        public double Price { get; set; }
    }
}
