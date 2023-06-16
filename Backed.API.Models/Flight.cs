using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Origin is Required")]
        public int AirportOriginId { get; set; }

        [Required(ErrorMessage = "Destination is Required")]
        public int AirportDestineId { get; set; }

        [Required(ErrorMessage = "DepartureTime is Required")]
        [MaxLength(50)]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "ArrivalTime is Required")]
        [MaxLength(50)]
        public string ArrivalTime { get; set; }

        [Required(ErrorMessage = "RouteFlight is Required")]
        public int RouteFlightId { get; set; }

        [ForeignKey ("RouteFlightId ")]
        public RouteFlight RouteFlight { get; set; }

        [ForeignKey("AirporOriginId")]
        public Airport AirportOrigin { get; set; }

        [ForeignKey("AirportDestineId")]
        public Airport AirportDestine { get; set; }        
    }
}
