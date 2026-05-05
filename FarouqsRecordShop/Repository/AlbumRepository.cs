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
    }
}