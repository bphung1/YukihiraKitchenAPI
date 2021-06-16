using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Directions;

namespace YukihiraKitchen.API.Controllers
{
    public class DirectionsController : BaseAPIController
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> Add(Guid id, DirectionParam param)
        {
            return HandleResult(await Mediator.Send(new Add.Command { RecipeId = id, Param = param}));
        }
    }
}
