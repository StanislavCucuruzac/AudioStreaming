using Moq;
using System;
using Xunit;

namespace Web_Api_UnitTests
{
    public class ArtistControllerTests
    {

        private readonly ArtistControllerTests _artistController;
        public ArtistControllerTests()
        {
            var mockArtistService = new Mock<IArtistService>();
            var artist = new List<ArtistDto>()
            {
                new ArtistDto
                {
                    Id =1,
                    Name ="Billie Elish",
                    Country = "USA",
                    FileStyleUriParser ="Pop"
                },
            }

        }


        [Fact]
        public void Test1()
        {

        }
    }
}
