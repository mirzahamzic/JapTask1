using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using norm_calc.Data;
using norm_calc.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace norm_calc.Data
{

    public class DatabaseSeed
    {
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public static async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Ingredients.Any())
                {
                    context.Ingredients.AddRange(
                        new Ingredient()
                        {
                            Name = "Brasno",
                            UnitQuantity = 10,
                            UnitPrice = 5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-1)

                        },
                        new Ingredient()
                        {
                            Name = "Secer",
                            UnitQuantity = 12,
                            UnitPrice = 7,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Ulje",
                            UnitQuantity = 25,
                            UnitPrice = 6.5,
                            UnitOfMeasure = "l",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Piletina",
                            UnitQuantity = 50,
                            UnitPrice = 7,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Maslinovo ulje",
                            UnitQuantity = 10,
                            UnitPrice = 12,
                            UnitOfMeasure = "l",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Trapist",
                            UnitQuantity = 18,
                            UnitPrice = 12,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Mocarela",
                            UnitQuantity = 8,
                            UnitPrice = 20,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Paradajz Sos",
                            UnitQuantity = 10,
                            UnitPrice = 5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Kvasac",
                            UnitQuantity = 7,
                            UnitPrice = 10,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Sampinjoni",
                            UnitQuantity = 5,
                            UnitPrice = 8.5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Cokalada",
                            UnitQuantity = 18,
                            UnitPrice = 25,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Kore za tortu",
                            UnitQuantity = 5,
                            UnitPrice = 20,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Orasi",
                            UnitQuantity = 10,
                            UnitPrice = 15,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        });

                    await context.SaveChangesAsync();
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
                            Name = "Pice",
                        },

                        new Category()
                        {
                            Name = "Paste",
                        },

                        new Category()
                        {
                            Name = "Antipaste",
                        });

                    await context.SaveChangesAsync();
                }



                if (!context.Users.Any())
                {
                    string password = "admin123456";
                    User user = new()
                    {
                        Name = "Admin"
                    };

                    byte[] passwordSalt;
                    byte[] passwordHash;

                    using (var hmac = new System.Security.Cryptography.HMACSHA512())
                    {
                        passwordSalt = hmac.Key;
                        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    }

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.Created_At = DateTime.Now;

                    context.Users.Add(user);
                    await context.SaveChangesAsync();

                };
            }
        }
    }
}
