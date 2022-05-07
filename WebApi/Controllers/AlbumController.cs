using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        ApiDbContext _dbContext;

        public AlbumController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var albums = await (from album in _dbContext.Albums
                         select new
                         {
                             Id = album.Id,
                             Name = album.Name,
                             ImageUrl = album.ImageUrl
                         }).ToListAsync();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _dbContext.Albums.Where(a => a.Id == id).Include(a => a.Songs).ToListAsync();
            return Ok(album);
        }
    }
}
