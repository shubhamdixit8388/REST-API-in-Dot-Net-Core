using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi.Data;
using WebApi.models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {

        private ApiDbContext _dbContext{ get; set; }

        public SongsController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: api/<SongsController>
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return (IEnumerable<Song>)_dbContext.Songs;
            /*  Examples -> change Ienumerable to IActionResult to send data with staus code
            return Ok(_dbContext.Songs);
            return BadRequest();
            return NotFound();
            return StatusCode(StatusCodes.Status401Unauthorized);*/
        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public Song Get(int id)
        {
            var song = _dbContext.Songs.Find(id);
            return song;
        }

        // POST api/<SongsController>
        [HttpPost]
        public void Post([FromBody] Song song)
        {
            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();
        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Song updatedSong)
        {
            var song = _dbContext.Songs.Find(id);
            if (song == null)
            {
                return NotFound("No record found with id " + id);
            }
            else
            {
                song.Title = updatedSong.Title;
                song.Language = updatedSong.Language;
                song.Duration = updatedSong.Duration;
                _dbContext.SaveChanges();
                return Ok("Record Updated Successfully");
            }
        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _dbContext.Songs.Find(id);
            if(song == null)
            {
                return NotFound("No record found with id " + id);
            }
            else
            {
                _dbContext?.Songs.Remove(song);
                _dbContext.SaveChanges();
                return Ok("Record Deleted Successfully");
            }
        }
    }
}
