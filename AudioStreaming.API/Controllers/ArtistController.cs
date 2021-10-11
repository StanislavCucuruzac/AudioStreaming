using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Artists;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudioStreaming.API.Controllers
{
    [ApiController]
    [Route("api/artists")]
    public class ArtistController : AppBaseController
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtists();
            return Ok(artists);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtist(int id)
        {
            var artistDto = await _artistService.GetArtist(id);
            if (artistDto == null)
            {
                return NotFound($"Artist with {id} doesn't exist");
            }
             return Ok(artistDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddArtist([FromBody] ArtistForUpdateDto artistForUpdateDto)
        {
            var artistDto = await _artistService.AddArtist(artistForUpdateDto);
            if (artistDto == null)
            {
                return BadRequest("Artist has not been added!");
            }
            
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
