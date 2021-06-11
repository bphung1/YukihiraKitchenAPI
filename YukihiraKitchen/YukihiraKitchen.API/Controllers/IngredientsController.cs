using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Ingredients;
using YukihiraKitchen.Domain;

namespace YukihiraKitchen.API.Controllers
{
    public class IngredientsController : BaseAPIController
    {
        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngredient(Ingredient ingredient)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Ingredient = ingredient }));
        }
    }
}
