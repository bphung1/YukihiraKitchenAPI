using Microsoft.AspNetCore.Mvc;
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
    }
}
