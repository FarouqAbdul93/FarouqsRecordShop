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
                new Album { Title = "Abbey Road", Artist = "The Beatles", Genre = "Rock", ReleaseYear = 1969, Stock = 5 },
                new Album { Title = "Thriller", Artist = "Michael Jackson", Genre = "Pop", ReleaseYear = 1982, Stock = 3 }
            });

            var service = new AlbumService(mockRepo.Object);

            var result = service.GetAllAlbums();

            result.Count.ShouldBe(2);
        }
    }
}
