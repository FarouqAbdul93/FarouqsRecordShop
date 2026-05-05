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
    }
}
