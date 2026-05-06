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

        [HttpPost]
        public ActionResult<Album> AddAlbum([FromBody] Album album)
        {
            var newAlbum = _service.AddAlbum(album);
            return CreatedAtAction(nameof(GetAlbumById), new { id = newAlbum.Id }, newAlbum);
        }

        [HttpPut("{id}")]
        public ActionResult<Album> UpdateAlbum(int id, [FromBody] Album album)
        {
            var updatedAlbum = _service.UpdateAlbum(id, album);

            if (updatedAlbum == null)
            {
                return NotFound();
            }

            return Ok(updatedAlbum);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            var deleted = _service.DeleteAlbum(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("artist/{artist}")]
        public ActionResult<List<Album>> GetAlbumsByArtist(string artist)
        {
            var albums = _service.GetAlbumsByArtist(artist);
            return Ok(albums);
        }

        [HttpGet("genre/{genre}")]
        public ActionResult<List<Album>> GetAlbumsByGenre(string genre)
        {
            var albums = _service.GetAlbumsByGenre(genre);
            return Ok(albums);
        }

        [HttpGet("year/{year}")]
        public ActionResult<List<Album>> GetAlbumsByReleaseYear(int year)
        {
            var albums = _service.GetAlbumsByReleaseYear(year);
            return Ok(albums);
        }

        [HttpGet("name/{title}")]
        public ActionResult<Album> GetAlbumByName(string title)
        {
            var album = _service.GetAlbumByName(title);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }
    }
}