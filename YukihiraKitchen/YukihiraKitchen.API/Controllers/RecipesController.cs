using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetRecipes()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")] // recipes/id
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecipe(Recipe recipe)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Recipe = recipe }));
        }

        [HttpPost("{id}/addRecipeIngredient")]
        public async Task<IActionResult> AddRecipeIngredient(Guid id, RecipeIngredientParam ingredientParam)
        {
            return HandleResult(await Mediator.Send(new AddRecipeIngredient.Command { Id = id, Param = ingredientParam }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRecipe(Guid id, Recipe recipe)
        {
            recipe.Id = id;

            return HandleResult(await Mediator.Send(new Edit.Command { Recipe = recipe }));
        }

        [HttpDelete("{id}/removeIngredient/{ingredientName}")]
        public async Task<IActionResult> RemoveRecipeIngredient(Guid id, string ingredientName)
        {
            return HandleResult(await Mediator.Send(new RemoveRecipeIngredient.Command { Id = id, IngredientName = ingredientName }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveRecipe(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
