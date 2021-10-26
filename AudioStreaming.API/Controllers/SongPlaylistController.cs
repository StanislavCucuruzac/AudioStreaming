using AudioStreaming.Bll.Commands;
using AudioStreaming.Bll.Queries.Playlist;
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

            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSong([FromBody] DeleteSongFromPlaylist command)
        {

            await Mediator.Send(command);

            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSongsByPlaylist(int id)
        {
            var result = await Mediator.Send(new GetSongByPlaylistIdQuery(id));
            return Ok(result);

             
        }
    }
}
