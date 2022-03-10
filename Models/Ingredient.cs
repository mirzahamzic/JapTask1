using System;
using System.Collections.Generic;

namespace norm_calc.Models
{
    public class GetIngredientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitQuantity { get; set; }
        public double UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
        public DateTime Created_at { get; set; }



        //many-to-many between ingredients and recipes
        public List<Recipe_Ingredient> Recipes_Ingredients { get; set; }
    }
}
