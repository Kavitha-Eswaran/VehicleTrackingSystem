using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class VehicleDto
    {
        [Required]
        public string VehicleNo { get; set; }
       
        [Required]
        public int UserId { get; set; }

    }
}