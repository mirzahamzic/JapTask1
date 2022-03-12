using System;
using System.Collections.Generic;

namespace norm_calc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? Created_At { get; set; }

        //Navigation properties
        public List<Recipe> Recipes { get; set; }

    }
}
