using Microsoft.EntityFrameworkCore;
using norm_calc.Models;

namespace norm_calc.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //many to many relationship override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe_Ingredient>()
                .HasOne(r => r.Recipe)
                .WithMany(ri => ri.Recipes_Ingredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<Recipe_Ingredient>()
                .HasOne(r => r.Ingredient)
                .WithMany(ri => ri.Recipes_Ingredients)
                .HasForeignKey(ri => ri.IngredientId);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe_Ingredient> Recipes_Ingredients { get; set; }
    }
}
