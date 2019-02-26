using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.JetAir.Data;
using API.JetAir.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.JetAir.Controllers
{
    [Route("api/[controller]")]
    public class SeatsController : Controller
    {
        JetAirDbContext context;
        public SeatsController(JetAirDbContext context)
        {
            this.context = context;
        }
        
        [HttpGet]
        public IEnumerable<Seat> Get()
        {
            var allocatedSeatIds = context.AllocatedSeats.Select(a => a.SeatId).ToArray();
            return this.context.Seats.Where(s => !allocatedSeatIds.Contains(s.SeatId)).ToList();
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
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
