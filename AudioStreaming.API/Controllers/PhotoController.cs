using AudioStreaming.Bll.Commands;
using AudioStreaming.Bll.Commands.Delete;
using AudioStreaming.Bll.Queries.Photo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    
    public class PhotoController : AppBaseController
    {             
      
        [HttpGet("getPhotoBaseString/{photoSlug}")]
        public async Task<IActionResult> GetPhotoBaseString(string photoPath)
        {
            var result = await Mediator.Send(new GetPhotoBaseStringBySlugQuery(photoPath));

            return Ok(result);
        }

        [HttpGet("getPhoto/{photoSlug}")]
        public async Task<IActionResult> GetPhoto(string photoSlug)
        {
            var result = await Mediator.Send(new GetPhotoBySlugQuery(photoSlug));
            if(result == null)
            {
                return BadRequest();
            }

            return File(result, "image/jpeg");
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromForm] UploadPhotoCommand command)
        {
          //  command.ArtistId = UserId;

            var path = await Mediator.Send(command);

            return CreatedAtAction(nameof(UploadPhoto), path);
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePhoto([FromBody] DeletePhotoCommand command)
        {
            command.ArtistId = UserId;

            await Mediator.Send(command);

            return Ok();
        }

       
    }
}
