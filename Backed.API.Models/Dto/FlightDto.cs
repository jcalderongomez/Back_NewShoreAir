using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.Models.Dto
{
    public class FlightDto
    {
        public int Id { get; set; }

        public int AirportOriginId { get; set; }

        public int AirportDestineId { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }

        public int RouteFlightId { get; set; }

        public RouteFlight RouteFlight { get; set; }

        public Airport AirportOrigin { get; set; }
        public Airport AirportDestine { get; set; }
    }
}
