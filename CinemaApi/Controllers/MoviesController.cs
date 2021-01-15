using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaApi.Data;
using CinemaApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private CinemaDbContext _dbContext;

        public MoviesController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_dbContext.Movies);
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null) return NotFound("Movie is not found");
            return Ok(movie);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public IActionResult Post([FromBody] Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie newMovie)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null) return NotFound("Movie is not found"); 
            else
            {
                movie.Name = newMovie.Name;
                movie.Language = newMovie.Language;
                _dbContext.SaveChanges();
                return Ok("Movie was updated");
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.Find(id);
            if (movie == null) return NotFound("Movie is not found");
            else
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return Ok("Movie was removed
            }
        }
    }
}
