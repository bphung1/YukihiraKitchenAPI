using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YukihiraKitchen.Application.Photos;

namespace YukihiraKitchen.API.Controllers
{
    public class PhotosController : BaseAPIController
    {
        [HttpPost("{id}")]
        public async Task<IActionResult> Add(IFormFile File, Guid id)
        {
            return HandleResult(await Mediator.Send(new Add.Command { File = File, Id = id}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Replace(IFormFile File, Guid id)
        {
            return HandleResult(await Mediator.Send(new Replace.Command { File = File, Id = id }));
        }
    }
}
