using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Details.Models;

namespace Vehicle_Details.Data
{
    public class MvcVehicleRegoContext : DbContext
    {
        public MvcVehicleRegoContext(DbContextOptions<MvcVehicleRegoContext> options) :base(options)
        {
        }
        public DbSet<VehicleRegistration> VehicleRegistration { get; set; }
        public DbSet<Vehicle_Details.Models.Category> Categories { get; set; }
    }
}
