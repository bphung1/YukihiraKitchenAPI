using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.Persistence
{
    public class DataSeeding
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName = "Bob", UserName = "bob", Email = "bob@test.com"}
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (context.Recipes.Any()) return;

            var ingredients = new List<Ingredient>
            { 
                new Ingredient
                {
                    IngredientName = "Egg"
                },
                new Ingredient
                {
                    IngredientName = "Cheese"
                },
                new Ingredient
                {
                    IngredientName = "Flour"
                },
                new Ingredient
                {
                    IngredientName = "Tomato sauce"
                },
                new Ingredient
                {
                    IngredientName = "Ham"
                },
                new Ingredient
                {
                    IngredientName = "Pineapple"
                },
            };

            var recipes = new List<Recipe>
            {
                new Recipe
                {
                    RecipeName = "Pizza",
                    Description = "An amazing pizza",
                    CookingDuration = 45,
                    Temperature = 450,
                },
                new Recipe
                {
                    RecipeName = "Lasagna",
                    Description = "An amazing lasagna",
                    CookingDuration = 90,
                    Temperature = 350,
                },
                new Recipe
                {
                    RecipeName = "Burrito",
                    Description = "An amazing burrito",
                    CookingDuration = 25,
                    Temperature = 275,
                },
                new Recipe
                {
                    RecipeName = "Fillet Mignon",
                    Description = "An amazing fillet mignon",
                    CookingDuration = 45,
                    Temperature = 350,
                },
                new Recipe
                {
                    RecipeName = "Steak",
                    Description = "An amazing steak",
                    CookingDuration = 10,
                    Temperature = 450,
                },
                new Recipe
                {
                    RecipeName = "Meatloaf",
                    Description = "An amazing meatloaf",
                    CookingDuration = 35,
                    Temperature = 350,
                },
                new Recipe
                {
                    RecipeName = "Roasted Chicken",
                    Description = "An amazing roasted chicken",
                    CookingDuration = 35,
                    Temperature = 375,
                },
                new Recipe
                {
                    RecipeName = "Roasted Pork Belly",
                    Description = "An amazing roasted poork belly",
                    CookingDuration = 120,
                    Temperature = 300,
                },
                new Recipe
                {
                    RecipeName = "Fried Shrimp",
                    Description = "An amazing fried shrimp",
                    CookingDuration = 10,
                    Temperature = 350,
                },
            };

            await context.Recipes.AddRangeAsync(recipes);
            await context.Ingredients.AddRangeAsync(ingredients);
            await context.SaveChangesAsync();
        }
    }
}
