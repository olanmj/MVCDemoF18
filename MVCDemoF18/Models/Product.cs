using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoF18.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be 3 to 20 characters")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(1, Double.MaxValue, ErrorMessage = "Price must be at least $1")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Category { set; get; }

     [Display(Name = "Total Due")]
        public decimal AmountDue
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
