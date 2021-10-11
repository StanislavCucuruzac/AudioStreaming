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
