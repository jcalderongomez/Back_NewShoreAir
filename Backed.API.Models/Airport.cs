using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backed.API.Models
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "IATACode is Required")]
        [MaxLength(5)]
        public string IATACode { get; set; }

        [Required(ErrorMessage = "Location is Required")]
        [MaxLength(50)]
        public string Location { get; set; }
        
    }
}
