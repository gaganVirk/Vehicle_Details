using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle_Details.ViewModels
{
    public class CategoryCreateViewModel
    {
        [Required]
        public int MinValue { get; set; }

        [Required]
        public int MaxValue { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(50)]
        public IFormFile ImageIcon { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(20)]
        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (IsInsideRange())
                {
                    type = value;
                }
            }
        }

        public bool IsValid()
        {
            return this.MinValue.CompareTo(this.MaxValue) <= 0;
        }
        public bool ContainsValue(int value)
        {
            return (this.MinValue.CompareTo(value) <= 0) && (value.CompareTo(this.MaxValue) <= 0);
        }

        public bool IsInsideRange()
        {
            CategoryCreateViewModel range = new CategoryCreateViewModel();
            return this.IsValid() && range.IsValid() && range.ContainsValue(this.MinValue) && range.ContainsValue(this.MaxValue);
        }

    }
}
