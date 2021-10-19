using AudioStreaming.Bll.Commands;
using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Bll.Queries.Song;
using AudioStreaming.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{      
    public class SongController : AppBaseController
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet("getSongs")]
        public async Task<IActionResult> GetSongs()
        {

            int.TryParse(Request.Query["loadFrom"].FirstOrDefault(), out int loadFrom);
            var result = await Mediator.Send(new GetSongsQuery(loadFrom));

            return result.Count == 0 ? NotFound() : Ok(result);
        }

        [HttpGet("getSongBaseString/{songSlug}")]
        public async Task<IActionResult> GetSongBaseString(string songSlug)
        {
            var result = await Mediator.Send(new GetSongBaseStringBySlugQuery(songSlug));

            return Ok(result);
        }

        [HttpGet("getSong/{songSlug}")]
        public async Task<IActionResult> GetSong(string songSlug)
        {
            var result = await Mediator.Send(new GetSongBySlugQuery(songSlug));

            return File(result, ".mp3");
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
        public async Task<IActionResult> UploadSong([FromForm] UploadSongCommand command)
        {
           
            var path = await Mediator.Send(command);

            return CreatedAtAction(nameof(UploadSong), path);
        }


    }
}
