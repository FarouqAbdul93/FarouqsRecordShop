using FarouqsRecordShop.Models;

namespace FarouqsRecordShop.Services
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album? GetAlbumById(int id);
        Album AddAlbum(Album album);
        Album? UpdateAlbum(int id, Album album);
        bool DeleteAlbum(int id);
        List<Album> GetAlbumsByArtist(string artist);
        List<Album> GetAlbumsByGenre(string genre);
        List<Album> GetAlbumsByReleaseYear(int year);
        Album? GetAlbumByName(string title);
    }
}