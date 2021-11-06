using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class VehicleLogDto
    {
        [Required]
        public string VehicleNo { get; set; }
        [Required] 
        public DateTime TimeStamp { get; set; }
    }
}