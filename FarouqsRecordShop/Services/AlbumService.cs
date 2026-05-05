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
    }
}