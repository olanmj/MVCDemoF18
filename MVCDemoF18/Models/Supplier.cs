using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoF18.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        // For demo only, not a production ready model
        public int ProductID { get; set; }
    }
}
