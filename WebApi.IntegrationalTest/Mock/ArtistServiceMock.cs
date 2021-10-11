using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.IntegrationalTest.Mock
{
    public class ArtistServiceMock : IArtistService
    {

        private IEnumerable<ArtistDto> artists = new List<ArtistDto>()
            {
                new ArtistDto
                {
                    Id = 1,
                    Name = "Billie Elish",
                    Country = "USA",
                    Style = "Pop"
                },
                 new ArtistDto
                {
                    Id = 2,
                    Name = "Morgenstern",
                    Country = "Russia",
                    Style = "Rap"
                },
                  new ArtistDto
                {
                    Id = 3,
                    Name = "Drake",
                    Country = "USA",
                    Style = "Pop"
                }

            };

        public Task<ArtistDto> AddArtist(ArtistForUpdateDto artistForUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArtistDto>> GetAllArtists()
        {
            return Task.FromResult(artists);
        }

        public Task<ArtistDto> GetArtist(int id)
        {
            return Task.FromResult(artists.FirstOrDefault(x => x.Id == id));
        }

        public Task UpdateArtist(int id, ArtistForUpdateDto artistForUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
