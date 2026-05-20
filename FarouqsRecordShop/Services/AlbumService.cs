using FarouqsRecordShop.Models;
using FarouqsRecordShop.Repository;

namespace FarouqsRecordShop.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _repository;

        public AlbumService(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public List<Album> GetAllAlbums()
        {
            return _repository.GetAllAlbums();
        }

        public Album? GetAlbumById(int id)
        {
            return _repository.GetAlbumById(id);
        }

        public Album AddAlbum(Album album)
        {
            return _repository.AddAlbum(album);
        }

        public Album? UpdateAlbum(int id, Album album)
        {
            return _repository.UpdateAlbum(id, album);
        }

        public bool DeleteAlbum(int id)
        {
            return _repository.DeleteAlbum(id);
        }

        public List<Album> GetAlbumsByArtist(string artist)
        {
            return _repository.GetAlbumsByArtist(artist);
        }

        public List<Album> GetAlbumsByGenre(string genre)
        {
            return _repository.GetAlbumsByGenre(genre);
        }

        public List<Album> GetAlbumsByReleaseYear(int year)
        {
            return _repository.GetAlbumsByReleaseYear(year);
        }

        public List<Album> SearchAlbumsByTitle(string title)
        {
            return _repository.SearchAlbumsByTitle(title);
        }

        public List<Album> SearchAlbumsByArtist(string artist)
        {
            return _repository.SearchAlbumsByArtist(artist);
        }

        public Album? GetAlbumByName(string title)
        {
            return _repository.GetAlbumByName(title);
        }
    }
}