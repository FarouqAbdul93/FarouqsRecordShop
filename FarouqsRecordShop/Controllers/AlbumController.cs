using FarouqsRecordShop.Models;
using FarouqsRecordShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarouqsRecordShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Album>> GetAllAlbums()
        {
            var albums = _service.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public ActionResult<Album> GetAlbumById(int id)
        {
            var album = _service.GetAlbumById(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }
    }
}