using norm_calc.Data;
using norm_calc.Models;
using System;
using System.Collections.Generic;

namespace norm_calc
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        //Navigation properties

        //one-to-many beetwen category and recipe
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //one-to-many beetwen user and recipe
        //public int UserId { get; set; }
        //public User? User { get; set; }

        //many-to-many between recipes and ingredients
        public List<Recipe_Ingredient> Recipes_Ingredients { get; set; }
    }
}
