using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Recipes;

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
    }
}
