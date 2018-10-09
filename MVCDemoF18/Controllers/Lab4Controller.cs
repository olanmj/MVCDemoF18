using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using WaffleGenerator;

namespace MVCDemoF18.Controllers
{
    public class Lab4Controller : Controller
    {
        public IActionResult Index()
        {
            DateTime date = DateTime.Now;
            return View(date);
        }

        public IActionResult Waffler()
        {
            var waffle = WaffleEngine.Html(2, true, false);
            return View(new HtmlString(waffle));
        }
    }
}