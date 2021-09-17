using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos;
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
        public async Task<IActionResult> AddSong(SongForUpdateDto songForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var songDto = await _songService.AddSong(songForUpdateDto);

            return CreatedAtAction(nameof(GetSong), new { id = songDto.Id }, songDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, SongForUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _songService.UpdateSong(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteSong(int id)
        {
            await _songService.DeleteSong(id);
        }
    }
}
