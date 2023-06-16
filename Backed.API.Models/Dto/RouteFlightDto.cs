using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.Models.Dto
{
    public class RouteFlightDto
    {
        public int Id { get; set; }
        public string RouteName { get; set; }
    }
}
