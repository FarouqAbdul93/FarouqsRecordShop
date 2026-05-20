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
                return NotFound(new { message = $"Album with ID {id} was not found."});
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
                return NotFound(new { message = $"Album with ID {id} was not found."});
            }

            return Ok(updatedAlbum);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAlbum(int id)
        {
            var deleted = _service.DeleteAlbum(id);

            if (!deleted)
            {
                return NotFound(new { message = $"Album with ID {id} was not found."});
            }

            return NoContent();
        }

        [HttpGet("artist/{artist}")]
        public ActionResult<List<Album>> GetAlbumsByArtist(string artist)
        {
            var albums = _service.GetAlbumsByArtist(artist);
            if (albums.Count == 0)
            {
                return NotFound(new { message = $"No albums found for artist '{artist}'." });
            }
            return Ok(albums);
        }

        [HttpGet("genre/{genre}")]
        public ActionResult<List<Album>> GetAlbumsByGenre(string genre)
        {
            var albums = _service.GetAlbumsByGenre(genre);
            if (albums.Count == 0)
            {
                return NotFound(new { message = $"No albums found for genre '{genre}'." });
            }
            return Ok(albums);
        }

        [HttpGet("year/{year}")]
        public ActionResult<List<Album>> GetAlbumsByReleaseYear(int year)
        {
            var albums = _service.GetAlbumsByReleaseYear(year);
            if (albums.Count == 0)
            {
                return NotFound(new { message = $"No albums found for release year '{year}'." });
            }
            return Ok(albums);
        }

        [HttpGet("search/title/{title}")]
        public ActionResult<List<Album>> SearchAlbumsByTitle(string title)
        {
            var albums = _service.SearchAlbumsByTitle(title);
            if (albums.Count == 0)
            {
                return NotFound(new { message = $"No albums found with title containing '{title}'." });
            }
            return Ok(albums);
        }

        [HttpGet("search/artist/{artist}")]
        public ActionResult<List<Album>> SearchAlbumsByArtist(string artist)
        {
            var albums = _service.SearchAlbumsByArtist(artist);
            if (albums.Count == 0)
            {
                return NotFound(new { message = $"No albums found with artist containing '{artist}'." });
            }
            return Ok(albums);
        }

        [HttpGet("name/{title}")]
        public ActionResult<Album> GetAlbumByName(string title)
        {
            var album = _service.GetAlbumByName(title);

            if (album == null)
            {
                return NotFound(new { message = $"Album with name '{title}' was not found."});
            }

            return Ok(album);
        }
    }
}
