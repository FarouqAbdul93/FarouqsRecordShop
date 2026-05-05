using FarouqsRecordShop.Models;

namespace FarouqsRecordShop.Repository
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();

        Album? GetAlbumById(int id);
        Album AddAlbum(Album album);
    }
}