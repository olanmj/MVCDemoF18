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
        private static List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            if (products.Count == 0)
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
            }
            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            // add p to products list 
            p.ProductID = products[products.Count - 1].ProductID + 1;
            products.Add(p);
            return RedirectToAction("Index");
        }

        public IActionResult Buy(int id, int quantity)
        {
            var prod = products.Find(p => p.ProductID == id);
            prod.Quantity = quantity;
            return View(prod);
        }
    }
}