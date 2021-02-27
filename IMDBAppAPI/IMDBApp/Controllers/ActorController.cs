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
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        // GET: api/<ActorController>
        [HttpGet, Route("all")]
        public IActionResult Get()
        {
            return Ok(_actorService.GetAll());
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var actor = _actorService.Get(id);
            return Ok(actor);
        }

        // POST api/<ActorController>
        [HttpPost]
        public IActionResult Post([FromBody] ActorRequest actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _actorService.Add(actor);
            return Ok(id);
        }

        // PUT api/<ActorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActorRequest actor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _actorService.Update(id, actor);
            return Ok();
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _actorService.Delete(id);
            return Ok();
        }
    }
}
