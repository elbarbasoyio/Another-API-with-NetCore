using CityInfoAPI.Models;
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
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities
                        .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city.PointOfInterests);
        }

        [HttpGet("{pointId}", Name = "GetPointOfInterest")]
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

        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(201)]
        public IActionResult CreatePointOfInterest(int cityId, 
            [FromBody] PointOfInterestForCreationDto pointsOfInterestForCreation)
        {
            if(pointsOfInterestForCreation.Description == pointsOfInterestForCreation.Name)
            {
                ModelState.AddModelError(
                    "Description",
                    "The provided description should be different from the name.");
            }
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound(ModelState);
            }

            //demo purposes
            var maxPointOfInterest = CitiesDataStore.Current.Cities
                .SelectMany(c => c.PointOfInterests).Max(p => p.Id);
            var finalPoint = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterest,
                Name = pointsOfInterestForCreation.Name,
                Description = pointsOfInterestForCreation.Description
            };
            city.PointOfInterests.Add(finalPoint);
            return CreatedAtRoute(
                "GetPointOfInterest",
                new { cityId, pointId = finalPoint.Id},
                finalPoint);
        }

    }
}
