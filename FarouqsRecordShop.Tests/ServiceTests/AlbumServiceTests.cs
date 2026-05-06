using FarouqsRecordShop.Models;
using FarouqsRecordShop.Repository;
using FarouqsRecordShop.Services;
using Moq;
using Shouldly;

namespace FarouqsRecordShop.Tests.ServiceTests
{
    public class AlbumServiceTests
    {
        [Test]
        public void GetAllAlbums_ReturnsAllAlbums()
        {
            var mockRepo = new Mock<IAlbumRepository>();

            mockRepo.Setup(r => r.GetAllAlbums()).Returns(new List<Album>
            {
                new Album { Title = "The Documentary", Artist = "The Game", Genre = "Hip-Hop", ReleaseYear = 2005, Stock = 5 },
                new Album { Title = "Thriller", Artist = "Michael Jackson", Genre = "Pop", ReleaseYear = 1982, Stock = 3 }
            });

            var service = new AlbumService(mockRepo.Object);

            var result = service.GetAllAlbums();

            result.Count.ShouldBe(2);
        }

        [Test]
        public void GetAlbumById_ReturnsCorrectAlbum()
        {
            var mockRepo = new Mock<IAlbumRepository>();

            mockRepo.Setup(r => r.GetAlbumById(1)).Returns(new Album
            {
                Id = 1,
                Title = "The Documentary",
                Artist = "The Game",
                Genre = "Hip-Hop",
                ReleaseYear = 2005,
                Stock = 5
            });

            var service = new AlbumService(mockRepo.Object);

            var result = service.GetAlbumById(1);

            result.ShouldNotBeNull();
            result.Title.ShouldBe("The Documentary");
        }

        [Test]
        public void AddAlbum_ReturnsNewAlbum()
        {
            var mockRepo = new Mock<IAlbumRepository>();

            var newAlbum = new Album { Title = "Konvicted", Artist = "Akon", Genre = "R&B", ReleaseYear = 2006, Stock = 5 };

            mockRepo.Setup(r => r.AddAlbum(newAlbum)).Returns(newAlbum);

            var service = new AlbumService(mockRepo.Object);

            var result = service.AddAlbum(newAlbum);

            result.ShouldNotBeNull();
            result.Title.ShouldBe("Konvicted");
        }

        [Test]
        public void UpdateAlbum_ReturnsUpdatedAlbum()
        {
            var mockRepo = new Mock<IAlbumRepository>();

            var updatedAlbum = new Album { Id = 1, Title = "Divide (Deluxe)", Artist = "Ed Sheeran", Genre = "Pop", ReleaseYear = 2017, Stock = 10 };

            mockRepo.Setup(r => r.UpdateAlbum(1, updatedAlbum)).Returns(updatedAlbum);

            var service = new AlbumService(mockRepo.Object);

            var result = service.UpdateAlbum(1, updatedAlbum);

            result.ShouldNotBeNull();
            result.Title.ShouldBe("Divide (Deluxe)");
        }

        [Test]
        public void UpdateAlbum_ReturnsNullWhenNotFound()
        {
            var mockRepo = new Mock<IAlbumRepository>();

            mockRepo.Setup(r => r.UpdateAlbum(99, It.IsAny<Album>())).Returns((Album?)null);

            var service = new AlbumService(mockRepo.Object);

            var result = service.UpdateAlbum(99, new Album());

            result.ShouldBeNull();
        }
    }
}
