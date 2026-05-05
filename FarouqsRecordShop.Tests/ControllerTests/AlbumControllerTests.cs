using FarouqsRecordShop.Controllers;
using FarouqsRecordShop.Models;
using FarouqsRecordShop.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace FarouqsRecordShop.Tests.ControllerTests
{
    public class AlbumControllerTests
    {
        [Test]
        public void GetAllAlbums_Returns200WithAlbums()
        {
            var mockService = new Mock<IAlbumService>();

            mockService.Setup(s => s.GetAllAlbums()).Returns(new List<Album>
            {
                new Album { Title = "Abbey Road", Artist = "The Beatles", Genre = "Rock", ReleaseYear = 1969, Stock = 5 },
                new Album { Title = "Thriller", Artist = "Michael Jackson", Genre = "Pop", ReleaseYear = 1982, Stock = 3 }
            });

            var controller = new AlbumController(mockService.Object);

            var result = controller.GetAllAlbums();

            var okResult = result.Result as OkObjectResult;
            okResult.ShouldNotBeNull();
            okResult.StatusCode.ShouldBe(200);

            var albums = okResult.Value as List<Album>;
            albums.Count.ShouldBe(2);
        }
    }
}
