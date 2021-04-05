using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle_Details.Models;

namespace Vehicle_Details.ViewModels
{
    public class MainPageViewModel
    {
        public IEnumerable<VehicleRegistration> VehicleRegistrations { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
