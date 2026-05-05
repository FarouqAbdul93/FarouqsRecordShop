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
    }
}