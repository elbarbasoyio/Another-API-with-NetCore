using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCitiesById(int id)
        {
            try
            {
                var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
                if (city != null)
                {
                    return Ok(city);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
           
        }

    }
}
