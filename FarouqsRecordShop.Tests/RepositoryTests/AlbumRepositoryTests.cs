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

        [Test]
        public void AddAlbum_AddsAndReturnsAlbum()
        {
            var context = GetInMemoryContext();
            var repo = new AlbumRepository(context);

            var newAlbum = new Album { Title = "Konvicted", Artist = "Akon", Genre = "R&B", ReleaseYear = 2006, Stock = 5 };

            var result = repo.AddAlbum(newAlbum);

            result.ShouldNotBeNull();
            result.Title.ShouldBe("Konvicted");
            context.Albums.Count().ShouldBe(1);
        }

        [Test]
        public void UpdateAlbum_UpdatesAndReturnsAlbum()
        {
            var context = GetInMemoryContext();

            context.Albums.Add(new Album { Title = "Divide", Artist = "Ed Sheeran", Genre = "Pop", ReleaseYear = 2017, Stock = 5 });
            context.SaveChanges();

            var repo = new AlbumRepository(context);

            var updatedAlbum = new Album { Title = "Divide (Deluxe)", Artist = "Ed Sheeran", Genre = "Pop", ReleaseYear = 2017, Stock = 10 };

            var result = repo.UpdateAlbum(1, updatedAlbum);

            result.ShouldNotBeNull();
            result.Title.ShouldBe("Divide (Deluxe)");
            result.Stock.ShouldBe(10);
        }

        [Test]
        public void UpdateAlbum_ReturnsNullWhenNotFound()
        {
            var context = GetInMemoryContext();
            var repo = new AlbumRepository(context);

            var result = repo.UpdateAlbum(99, new Album { Title = "Divide", Artist = "Ed Sheeran", Genre = "Pop", ReleaseYear = 2017, Stock = 5 });

            result.ShouldBeNull();
        }
    }
}
