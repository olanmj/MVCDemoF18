using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVCDemoF18.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            string greeting = "Hello from the Index method";
            // If the first parameter to View is a string, it is
            // interpreted as the name of the view file
            return View("Index", greeting);
        }

        public string Welcome()
        {
            return "Hello MVC";
        }

        public string Hello(string name, int count, int id)
        {
            return $"Hello {name}, your ID = {id} and count = {count}";
        }
    }
}