using Microsoft.AspNetCore.Mvc;
using WASM.API.Data;
using WASMLibrary.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WASM.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext context;

        public CountriesController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: <CountriesController>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return context.Countries.ToList();
        }

        // GET <CountriesController>/5
        [HttpGet("{id}")]
        public Country Get(int id)
        {
            return context.Countries.FirstOrDefault(c => c.Id == id);
        }

        // POST <CountriesController>
        [HttpPost]
        public void Post([FromBody] Country value)
        {
            context.Countries.Add(value);
            context.SaveChanges();
        }

        // PUT <CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Country value)
        {
            var country = context.Countries.FirstOrDefault(c => c.Id == id);
            country.Name = value.Name;
            context.Countries.Update(country);
            context.SaveChanges();
        }

        // DELETE <CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var country = context.Countries.FirstOrDefault(c => c.Id == id);
            context.Countries.Remove(country);
            context.SaveChanges();
        }
    }
}
