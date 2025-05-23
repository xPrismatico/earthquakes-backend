using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarthquakesController(DataContext context) : ControllerBase
    {
        [HttpGet] // https://localhost:5001/api/earthquakes
        public async Task<ActionResult<List<Earthquake>>> GetEarthquakes()
        {
            return await context.Earthquakes.ToListAsync();
        }
    }
}
