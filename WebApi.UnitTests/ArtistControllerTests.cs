using AudioStreaming.API.Controllers;
using AudioStreaming.Bll.Interfaces;
using AudioStreaming.Common.Dtos.Artists;
using Moq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Xunit;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.UnitTests
{
    public class ArtistControllerTests
    {

        private readonly ArtistController _artistController;

        public ArtistControllerTests()
        {
            var mockArtistService = new Mock<IArtistService>();
            var artists = new List<ArtistDto>()
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

            mockArtistService.Setup(x => x.GetAllArtists()).ReturnsAsync(new List<ArtistDto>(artists));
            mockArtistService.Setup(x => x.GetArtist(It.IsAny<int>())).ReturnsAsync((int id) => artists.Find(x => x.Id == id));
            _artistController = new ArtistController(mockArtistService.Object);

        }
        [Fact]
        public async Task Get_Artists_Returns_ListOfArtists()
        {
            //Act
            var result = await _artistController.GetAllArtists() as ObjectResult;
            var artists = result.Value as List<ArtistDto>;
            //Assert
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(3, artists.Count);

        }
        [Fact]
        public async Task GetArtist_GetExistingArtistId_ReturnsOkResult()
        {
            //Arange
            var id = 1;
            //Act
            var result = await _artistController.GetArtist(id) as ObjectResult;
            var artist = result.Value as ArtistDto;

            //Assert
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(id, artist.Id);
        }

        [Fact]
        public async Task GetArtist_GetNotExistingArtistId_ReturnsBadRequest()
        {
            //Arange
            var id = 100;
            //Act
            var result = await _artistController.GetArtist(id) as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);
            Assert.Equal($"Artist with {id} doesn't exist", result.Value);
        }

        [Fact]
        public async Task Post_AddArtist_Returns_AddedArtist()
        {

            //Arange
            var artistToAdd = new ArtistForUpdateDto();
            var mock = new Mock<IArtistService>();

            mock.Setup(x => x.AddArtist(It.IsAny<ArtistForUpdateDto>())).ReturnsAsync(new ArtistDto());

            //Act
            var result = await new ArtistController(mock.Object).AddArtist(artistToAdd);
            //Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetArtist", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task Post_AddArtist_Returns_BadRequest()
        {
            //Arange
            var artistToAdd = new ArtistForUpdateDto();
            var mock = new Mock<IArtistService>();

            mock.Setup(x => x.AddArtist(It.IsAny<ArtistForUpdateDto>()));


            //Act
            var result = await new ArtistController(mock.Object).AddArtist(artistToAdd) as ObjectResult;

            //Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("Artist has not been added!", result.Value);

        }


    }
}
