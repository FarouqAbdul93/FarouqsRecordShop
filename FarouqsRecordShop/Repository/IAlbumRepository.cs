using FarouqsRecordShop.Models;

namespace FarouqsRecordShop.Repository
{
    public interface IAlbumRepository
    {
        List<Album> GetAllAlbums();
    }
}