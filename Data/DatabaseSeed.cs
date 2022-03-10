using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using norm_calc.Data;
using norm_calc.Models;
using System;
using System.Linq;

namespace norm_calc.Data
{
    public class DatabaseSeed
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(
                        new GetIngredientDto()
                        {
                            Name = "Brasno",
                            UnitQuantity = 1,
                            UnitPrice = 5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-1)

                        },
                        new GetIngredientDto()
                        {
                            Name = "Secer",
                            UnitQuantity = 1,
                            UnitPrice = 7,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new GetIngredientDto()
                        {
                            Name = "Ulje",
                            UnitQuantity = 1,
                            UnitPrice = 6.5,
                            UnitOfMeasure = "l",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new GetIngredientDto()
                        {
                            Name = "Piletina",
                            UnitQuantity = 1,
                            UnitPrice = 7,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new GetIngredientDto()
                        {
                            Name = "Maslinovo ulje",
                            UnitQuantity = 1,
                            UnitPrice = 12,
                            UnitOfMeasure = "l",
                            Created_at = DateTime.Now.AddDays(-2)

                        });

                    context.SaveChanges();
                }

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category()
                        {
                            Name = "Pite",
                        },

                        new Category()
                        {
                            Name = "Kolaci",
                        },

                        new Category()
                        {
                            Name = "Torte",
                        },

                        new Category()
                        {
                            Name = "Meksicka",
                        },

                        new Category()
                        {
                            Name = "Italijanska",
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}
