using IMDBApp.Models.Request;
using IMDBAppAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDBApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/<MovieController>
        [HttpGet, Route("all")]
        public IActionResult Get()
        {
            return Ok(_movieService.GetAll());
        }


        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _movieService.Get(id);
            return Ok(movie);
        }

        // POST api/<MovieController>
        [HttpPost]
        public IActionResult Post([FromBody] MovieRequest movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _movieService.Add(movie);
            return Ok(new { MovieId = id });
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovieRequest movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _movieService.Update(id, movie);
            return Ok();
        }

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
