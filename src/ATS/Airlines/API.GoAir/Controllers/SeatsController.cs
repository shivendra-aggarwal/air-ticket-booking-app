using API.GoAir.Data;
using API.GoAir.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.GoAir.Controllers
{
    [Route("api/[controller]")]
    public class SeatsController : Controller
    {
        GoAirDbContext context;
        public SeatsController(GoAirDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            var allocatedSeatIds = context.AllocatedSeats.Select(a => a.SeatId).ToArray();
            return context.Seats.Where(s => !allocatedSeatIds.Contains(s.SeatId)).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
