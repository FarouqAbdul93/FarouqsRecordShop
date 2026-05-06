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
    }
}