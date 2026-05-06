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
                new Album { Title = "The Documentary", Artist = "The Game", Genre = "Hip-Hop", ReleaseYear = 2005, Stock = 5 },
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

        [Test]
        public void GetAlbumById_Returns200WithAlbum()
        {
            var mockService = new Mock<IAlbumService>();

            mockService.Setup(s => s.GetAlbumById(1)).Returns(new Album
            {
                Id = 1,
                Title = "The Documentary",
                Artist = "The Game",
                Genre = "Hip-Hop",
                ReleaseYear = 2005,
                Stock = 5
            });

            var controller = new AlbumController(mockService.Object);

            var result = controller.GetAlbumById(1);

            var okResult = result.Result as OkObjectResult;
            okResult.ShouldNotBeNull();
            okResult.StatusCode.ShouldBe(200);

            var album = okResult.Value as Album;
            album.Title.ShouldBe("The Documentary");
        }

        [Test]
        public void GetAlbumById_Returns404WhenNotFound()
        {
            var mockService = new Mock<IAlbumService>();

            mockService.Setup(s => s.GetAlbumById(99)).Returns((Album?)null);

            var controller = new AlbumController(mockService.Object);

            var result = controller.GetAlbumById(99);

            var notFoundResult = result.Result as NotFoundResult;
            notFoundResult.ShouldNotBeNull();
            notFoundResult.StatusCode.ShouldBe(404);
        }

        [Test]
        public void AddAlbum_Returns201WithNewAlbum()
        {
            var mockService = new Mock<IAlbumService>();

            var newAlbum = new Album { Id = 1, Title = "Konvicted", Artist = "Akon", Genre = "R&B", ReleaseYear = 2006, Stock = 5 };

            mockService.Setup(s => s.AddAlbum(newAlbum)).Returns(newAlbum);

            var controller = new AlbumController(mockService.Object);

            var result = controller.AddAlbum(newAlbum);

            var createdResult = result.Result as CreatedAtActionResult;
            createdResult.ShouldNotBeNull();
            createdResult.StatusCode.ShouldBe(201);

            var album = createdResult.Value as Album;
            album.Title.ShouldBe("Konvicted");
        }

        [Test]
        public void UpdateAlbum_Returns200WithUpdatedAlbum()
        {
            var mockService = new Mock<IAlbumService>();

            var updatedAlbum = new Album { Id = 1, Title = "Divide (Deluxe)", Artist = "Ed Sheeran", Genre = "Pop", ReleaseYear = 2017, Stock = 10 };

            mockService.Setup(s => s.UpdateAlbum(1, updatedAlbum)).Returns(updatedAlbum);

            var controller = new AlbumController(mockService.Object);

            var result = controller.UpdateAlbum(1, updatedAlbum);

            var okResult = result.Result as OkObjectResult;
            okResult.ShouldNotBeNull();
            okResult.StatusCode.ShouldBe(200);

            var album = okResult.Value as Album;
            album.Title.ShouldBe("Divide (Deluxe)");
        }

        [Test]
        public void UpdateAlbum_Returns404WhenNotFound()
        {
            var mockService = new Mock<IAlbumService>();

            mockService.Setup(s => s.UpdateAlbum(99, It.IsAny<Album>())).Returns((Album?)null);

            var controller = new AlbumController(mockService.Object);

            var result = controller.UpdateAlbum(99, new Album());

            var notFoundResult = result.Result as NotFoundResult;
            notFoundResult.ShouldNotBeNull();
            notFoundResult.StatusCode.ShouldBe(404);
        }

        [Test]
        public void DeleteAlbum_Returns204WhenDeleted()
        {
            var mockService = new Mock<IAlbumService>();

            mockService.Setup(s => s.DeleteAlbum(1)).Returns(true);

            var controller = new AlbumController(mockService.Object);

            var result = controller.DeleteAlbum(1);

            var noContentResult = result as NoContentResult;
            noContentResult.ShouldNotBeNull();
            noContentResult.StatusCode.ShouldBe(204);
        }

        [Test]
        public void DeleteAlbum_Returns404WhenNotFound()
        {
            var mockService = new Mock<IAlbumService>();

            mockService.Setup(s => s.DeleteAlbum(99)).Returns(false);

            var controller = new AlbumController(mockService.Object);

            var result = controller.DeleteAlbum(99);

            var notFoundResult = result as NotFoundResult;
            notFoundResult.ShouldNotBeNull();
            notFoundResult.StatusCode.ShouldBe(404);
        }
    }
}
