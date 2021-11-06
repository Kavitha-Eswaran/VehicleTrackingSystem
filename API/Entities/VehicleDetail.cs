using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class VehicleDetail
    {
        public int Id { get; set; }
        [Required]
        public string VehicleNo { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]        
        public int IsActive { get; set; }
    }
}