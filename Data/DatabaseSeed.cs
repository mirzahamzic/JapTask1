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
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        public static void Seed(IApplicationBuilder applicationBuilder)
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
                            UnitQuantity = 1,
                            UnitPrice = 5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-1)

                        },
                        new Ingredient()
                        {
                            Name = "Secer",
                            UnitQuantity = 1,
                            UnitPrice = 7,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Ulje",
                            UnitQuantity = 1,
                            UnitPrice = 6.5,
                            UnitOfMeasure = "l",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Piletina",
                            UnitQuantity = 1,
                            UnitPrice = 7,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Maslinovo ulje",
                            UnitQuantity = 1,
                            UnitPrice = 12,
                            UnitOfMeasure = "l",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Trapist",
                            UnitQuantity = 1,
                            UnitPrice = 12,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Mocarela",
                            UnitQuantity = 1,
                            UnitPrice = 20,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Paradajz Sos",
                            UnitQuantity = 1,
                            UnitPrice = 5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Kvasac",
                            UnitQuantity = 1,
                            UnitPrice = 10,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Sampinjoni",
                            UnitQuantity = 1,
                            UnitPrice = 8.5,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Cokalada",
                            UnitQuantity = 1,
                            UnitPrice = 15,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Kore za tortu",
                            UnitQuantity = 1,
                            UnitPrice = 20,
                            UnitOfMeasure = "kg",
                            Created_at = DateTime.Now.AddDays(-2)

                        }, new Ingredient()
                        {
                            Name = "Orasi",
                            UnitQuantity = 1,
                            UnitPrice = 15,
                            UnitOfMeasure = "kg",
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

                    context.SaveChanges();
                }





                if (!context.Users.Any())
                {
                    string password = "passwordone";
                    User user = new()
                    {
                        Name = "User one"
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

                    context.SaveChanges();

                };
            }
        }
    }
}
