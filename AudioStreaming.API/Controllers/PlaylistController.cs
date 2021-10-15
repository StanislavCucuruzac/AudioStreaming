using AudioStreaming.Bll.Commands;
using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Playlists;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    public class PlaylistController : AppBaseController
    {
        private readonly IPlaylistService _service;
        public PlaylistController(IPlaylistService artistService)
        {
            _service = artistService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist([FromBody] PlaylistForUpdateDto playlistForUpdateDto)
        {
            var playlistDto = await _service.AddPlaylist(playlistForUpdateDto);
            if (playlistDto == null)
            {
                return BadRequest("Artist has not been added!");
            }

            return CreatedAtAction(nameof(GetById), new { id = playlistDto.Id }, playlistForUpdateDto);
        }
            

        [HttpGet]
        public async Task<IEnumerable<PlaylistDto>> GetAllPlaylist()
        {
            var playlist = await _service.GetAllPlaylists();
            return playlist;

        }
        [HttpGet("{id}")]
        public async Task<PlaylistDto> GetById(int id)
        {
            var result = await _service.GetPlaylist(id);
            return result;
        }
    }
}
