using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class VehicleLocationDto
    {
        [Required]
        public string VehicleNo { get; set; }
        [Required] 
        public DateTime TimeStamp { get; set; }
        [Required] 
        public string Location { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}