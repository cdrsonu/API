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
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        // GET: api/<ProducerController>
        [HttpGet, Route("all")]
        public IActionResult Get() => Ok(_producerService.GetAll());

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var producer = _producerService.Get(id);
            return Ok(producer);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public IActionResult Post([FromBody] ProducerRequest producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _producerService.Add(producer);
            return Ok(id);
        }

        // PUT api/<ProducerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProducerRequest producer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _producerService.Update(id, producer);
            return Ok();
        }

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _producerService.Delete(id);
            return Ok();
        }
    }
}
