using FarouqsRecordShop.Models;

namespace FarouqsRecordShop.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly RecordShopContext _context;

        public AlbumRepository(RecordShopContext context)
        {
            _context = context;
        }

        public List<Album> GetAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public Album? GetAlbumById(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.Id == id);
        }

        public Album AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
            return album;
        }

        public Album? UpdateAlbum(int id, Album album)
        {
            var existingAlbum = _context.Albums.FirstOrDefault(a => a.Id == id);

            if (existingAlbum == null)
            {
                return null;
            }

            existingAlbum.Title = album.Title;
            existingAlbum.Artist = album.Artist;
            existingAlbum.Genre = album.Genre;
            existingAlbum.ReleaseYear = album.ReleaseYear;
            existingAlbum.Stock = album.Stock;

            _context.SaveChanges();
            return existingAlbum;
        }

        public bool DeleteAlbum(int id)
        {
            var album = _context.Albums.FirstOrDefault(a => a.Id == id);

            if (album == null)
            {
                return false;
            }

            _context.Albums.Remove(album);
            _context.SaveChanges();
            return true;
        }
    }
}