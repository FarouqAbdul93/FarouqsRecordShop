using FarouqsRecordShop.Models;
using FarouqsRecordShop.Repository;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace FarouqsRecordShop.Tests.RepositoryTests
{
    public class AlbumRepositoryTests
    {
        private RecordShopContext GetInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<RecordShopContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new RecordShopContext(options);
        }

        [Test]
        public void GetAllAlbums_ReturnsAllAlbums()
        {
            var context = GetInMemoryContext();

            context.Albums.AddRange(new List<Album>
            {
                new Album { Title = "The Documentary", Artist = "The Game", Genre = "Hip-Hop", ReleaseYear = 2005, Stock = 5 },
                new Album { Title = "Thriller", Artist = "Michael Jackson", Genre = "Pop", ReleaseYear = 1982, Stock = 3 }
            });
            context.SaveChanges();

            var repo = new AlbumRepository(context);

            var result = repo.GetAllAlbums();

            result.Count.ShouldBe(2);
        }

        [Test]
        public void GetAlbumById_ReturnsCorrectAlbum()
        {
            var context = GetInMemoryContext();

            context.Albums.Add(new Album { Title = "The Documentary", Artist = "The Game", Genre = "Hip-Hop", ReleaseYear = 2005, Stock = 5 });
            context.SaveChanges();

            var repo = new AlbumRepository(context);

            var result = repo.GetAlbumById(1);

            result.ShouldNotBeNull();
            result.Title.ShouldBe("The Documentary");
        }
    }
}
