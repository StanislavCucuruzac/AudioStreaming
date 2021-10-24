using AudioStreaming.Bll.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{     
    public class SongPlaylistController : AppBaseController
    {
     
        [HttpPost]
        public async Task<IActionResult> AddSong([FromBody] AddSongToPlaylistCommand command)
        {
          //  command.PlaylistId = UserId;

            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSong([FromBody] DeleteSongFromPlaylist command)
        {
         //   command.PlaylistId = UserId;

            await Mediator.Send(command);

            return Ok();
        }
    }
}
