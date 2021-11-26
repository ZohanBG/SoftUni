using CarDealer.Models;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class CarsInputDto
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public int[] PartsId { get; set; }
    }
}
