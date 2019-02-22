using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.A2b.Data;
using API.A2b.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.A2b.Controllers
{
    [Route("api/[controller]")]
    public class MealsController : Controller
    {
        private A2bDbContext a2BDbContext;
        public MealsController(A2bDbContext a2BDbContext)
        {
            this.a2BDbContext = a2BDbContext;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Meal> Get()
        {
            return this.a2BDbContext.Meals.ToList();
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
