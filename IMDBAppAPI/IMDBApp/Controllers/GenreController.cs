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
    public class GenreController : ControllerBase
    {

        private readonly IGenreService _genreService;

        public GenreController(IGenreService generService)
        {
            _genreService = generService;
        }

        // GET: api/<GenreController>
        [HttpGet, Route("all")]
        public IActionResult Get()
        {
            return Ok(_genreService.GetAll());
        }

        // GET api/<GenreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var genre = _genreService.Get(id);
            return Ok(genre);
        }

        // POST api/<GenreController>
        [HttpPost]
        public IActionResult Post([FromBody] GenreRequest genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _genreService.Add(genre);
            return Ok(id);
        }

        // PUT api/<GenreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GenreRequest genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _genreService.Update(id, genre);
            return Ok();
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _genreService.Delete(id);
            return Ok();
        }

    }
}
