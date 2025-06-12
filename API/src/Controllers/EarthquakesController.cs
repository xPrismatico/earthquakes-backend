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
        public async Task<ActionResult<List<Earthquake>>> GetEarthquakes(
            [FromQuery] DateOnly? startDate,
            [FromQuery] DateOnly? endDate,
            [FromQuery] double? minLatitude,
            [FromQuery] double? maxLatitude,
            [FromQuery] double? minLongitude,
            [FromQuery] double? maxLongitude,
            [FromQuery] double? minMagnitude,
            [FromQuery] double? maxMagnitude
        )

        {
            var query = context.Earthquakes.AsQueryable();

            // Filtro por rango de fechas
            if (startDate.HasValue)
                query = query.Where(e => e.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(e => e.Date <= endDate.Value);

            // Filtro por latitud
            if (minLatitude.HasValue)
                query = query.Where(e => e.Latitude >= minLatitude.Value);

            if (maxLatitude.HasValue)
                query = query.Where(e => e.Latitude <= maxLatitude.Value);

            // Filtro por longitud
            if (minLongitude.HasValue)
                query = query.Where(e => e.Longitude >= minLongitude.Value);

            if (maxLongitude.HasValue)
                query = query.Where(e => e.Longitude <= maxLongitude.Value);

            // Filtro por magnitud
            if (minMagnitude.HasValue)
                query = query.Where(e => e.Magnitude >= minMagnitude.Value);

            if (maxMagnitude.HasValue)
                query = query.Where(e => e.Magnitude <= maxMagnitude.Value);

            // Devuelvo la lista filtrada
            return await query.ToListAsync();
        }
    }
}
