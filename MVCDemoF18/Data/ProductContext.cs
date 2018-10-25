using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCDemoF18.Models;

namespace MVCDemoF18.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext (DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<MVCDemoF18.Models.Product> Product { get; set; }

        public DbSet<MVCDemoF18.Models.Supplier> Supplier { get; set; }
    }
}
