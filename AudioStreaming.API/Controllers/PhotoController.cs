using AudioStreaming.Bll.Commands;
using AudioStreaming.Bll.Commands.Delete;
using AudioStreaming.Bll.Queries.Photo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    public class PhotoController : AppBaseController
    {
        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetPhoto(int? artistId = null)
        {
            if (artistId == null)
                artistId = UserId;

            var result = await Mediator.Send(new GetPhotoSlugByArtistIdQuery(artistId.Value));

            return result == null ? NotFound() : Ok(result);
        }              

      
        [HttpGet("{photoSlug}")]
        public async Task<IActionResult> GetPhotoBaseString(string photoPath)
        {
            var result = await Mediator.Send(new GetPhotoBaseStringBySlugQuery(photoPath));

            return Ok(result);
        }

        [HttpGet("{photoSlug}")]
        public async Task<IActionResult> GetPhoto(string photoPath)
        {
            var result = await Mediator.Send(new GetPhotoSlugByQuery(photoPath));

            return File(result, "image/jpeg");
        }

      
        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromBody] UploadPhotoCommand command)
        {
            command.ArtistId = UserId;

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
