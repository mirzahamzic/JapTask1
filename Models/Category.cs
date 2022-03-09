using System.Collections.Generic;

namespace norm_calc.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation properties
        public List<Recipe> Recipes { get; set; }
    }

}
