using AudioStreaming.Bll.Commands;
using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    [Route("api/songs")]
    public class SongController : AppBaseController
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IEnumerable<SongListDto>> GetAllSongs()
        {
            var songs = await _songService.GetAllSongs();
            return songs;
        }


        [HttpGet("{id}")]
        public async Task<SongDto> GetSong(int id)
        {
            var songDto = await _songService.GetSong(id);
            return songDto;
        }

        [HttpPost]
        public async Task<IActionResult> UploadSong([FromBody] UploadSongCommand command)
        {
            command.UserId = UserId;

            var path = await Mediator.Send(command);

            return CreatedAtAction(nameof(UploadSong), path);
        }


    }
}
