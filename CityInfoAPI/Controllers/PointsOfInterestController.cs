using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/[controller]")]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult GetPointsOfInterest(int cityId, int pointId)
        {
            var city = CitiesDataStore.Current.Cities
                        .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            var point = city.PointOfInterests
                        .FirstOrDefault(p => p.Id == pointId);
            if(point == null)
            {
                return NotFound();
            }
            return Ok(point);
        }

    }
}
