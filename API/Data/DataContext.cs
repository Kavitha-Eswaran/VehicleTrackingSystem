using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API.Data
{
    public class DataContext : DbContext
    {
        // This is mandatory constructor to be created. Otherwise we will get error.
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<VehicleDetail> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VehiclePosition> VehicleLocations { get; set; }

    }
}