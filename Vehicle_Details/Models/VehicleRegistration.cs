using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Details.Models
{
    public class VehicleRegistration
    {
        [Required]
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public Manufactuer Manufacturer { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^\d+\.?\d{0,2}$")]
        public decimal Weight { get; set; }
        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
