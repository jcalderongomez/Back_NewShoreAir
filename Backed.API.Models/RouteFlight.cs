using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.Models
{
    public class RouteFlight
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "NameRoute is Required")]
        [MaxLength(50)]

        public string RouteName{ get; set; }
    }
}
