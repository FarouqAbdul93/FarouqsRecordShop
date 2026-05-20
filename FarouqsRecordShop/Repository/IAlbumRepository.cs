using FarouqsRecordShop.Models;

namespace FarouqsRecordShop.Repository
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();

        Album? GetAlbumById(int id);
        Album AddAlbum(Album album);
        Album? UpdateAlbum(int id, Album album);
        bool DeleteAlbum(int id);
        List<Album> GetAlbumsByArtist(string artist);
        List<Album> GetAlbumsByGenre(string genre);
        List<Album> GetAlbumsByReleaseYear(int year);
        List<Album> SearchAlbumsByTitle(string title);
        List<Album> SearchAlbumsByArtist(string artist);
        Album? GetAlbumByName(string title);
    }
}