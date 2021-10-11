using AudioStreaming.API;
using AudioStreaming.Common.Dtos.Artists;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.IntegrationalTests
{
    public class ArtistControllerWithCustompWebAppFactory : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;

        public ArtistControllerWithCustompWebAppFactory(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_Returns_ListOfArtists()
        {
            //Arange
            var client = _factory.CreateClient();
            var request = "/api/artists";
            //Act
            var artists = await client.GetFromJsonAsync<List<ArtistDto>>(request);
            //Assert
            Assert.NotNull(artists);
            Assert.Equal(3, artists.Count);
        }

        [Fact]
        public async Task GetArtist_Returns_ArtistById()
        {
            //Arange
            var client = _factory.CreateClient();
            var request = "/api/artists/1";
            //Act
            var artist = await client.GetFromJsonAsync<ArtistDto>(request);
            
            //Assert
            Assert.Equal(1, artist.Id);
            
        }

        [Fact]
        public async Task GetArtist_Returns_BadRequest()
        {
            //Arange
            var client = _factory.CreateClient();
            var request = "/api/artists/4";
            //Act
            var result = await client.GetAsync(request);
            var response = result.Content.ReadAsStringAsync();
            //Assert
            Assert.Equal(404, (int)result.StatusCode);
            Assert.Equal("Artist with 4 doesn't exist", response.Result);

        }
    }
}