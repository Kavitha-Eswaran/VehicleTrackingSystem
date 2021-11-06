using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class VehiclePosition
    {
        public int Id { get; set; }
        [Required]
        public string VehicleNo { get; set; }
        public VehicleDetail VehicleDetail { get; set; }
        [Required] 
        public DateTime TimeStamp { get; set; }
        [Required] 
        public string Location { get; set; }
    }
}