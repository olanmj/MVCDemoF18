using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCDemoF18.Models;

namespace MVCDemoF18.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            Product p = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 750M,
                Quantity = 2,
                Category = "Watersports"
            };
            products.Add(p);
            return View(products);
        }
    }
}