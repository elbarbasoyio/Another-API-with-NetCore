using CityInfoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfoAPI
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto
                {
                    Id = 1,
                    Name = "New York",
                    Description = "horrible",
                    PointOfInterests = new List<PointOfInterestDto>()
                    { 
                        new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "NYC",
                            Description = "horrible horrible"
                        }
                    }
                },
                new CityDto
                {
                    Id = 2,
                    Name = "Buenos Aires",
                    Description = "infumable",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 11,
                            Name = "BSAS",
                            Description = "infumable infumable"
                        }
                    }
                }
            };

        }
    }
}
