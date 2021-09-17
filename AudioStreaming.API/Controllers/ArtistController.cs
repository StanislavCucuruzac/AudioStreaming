using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Artists;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    [Route("api/artists")]
    public class ArtistController : AppBaseController
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }
        [HttpGet]
        public async Task<IEnumerable<ArtistListDto>> GetAllArtists()
        {
            var artist = await _artistService.GetAllArtists();
            return artist;
        }


        [HttpGet("{id}")]
        public async Task<ArtistDto> GetArtist(int id)
        {
            var artistDto = await _artistService.GetArtist(id);
            return artistDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddArtist(ArtistForUpdateDto artistForUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var artistDto = await _artistService.AddArtist(artistForUpdateDto);

            return CreatedAtAction(nameof(GetArtist), new { id = artistDto.Id }, artistDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(int id, ArtistForUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _artistService.UpdateArtist(id, dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteArtist(int id)
        {
            await _artistService.DeleteArtist(id);
        }
    }
}
