using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Recipes;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.API.Controllers
{
    public class RecipesController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")] // recipes/id
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Recipe = recipe }));
        }

        [HttpPost("{id}/addRecipeIngredient")]
        public async Task<IActionResult> AddRecipeIngredient(Guid id, RecipeIngredientParam ingredientParam)
        {
            return HandleResult(await Mediator.Send(new UpdateRecipe.Command { Id = id, Param = ingredientParam}));
        }
    }
}
