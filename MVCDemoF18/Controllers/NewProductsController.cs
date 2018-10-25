﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCDemoF18.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVCDemoF18.Controllers
{
    public class NewProductsController : Controller
    {
        private readonly ProductContext _context;
        private string apiKey;
        public NewProductsController(ProductContext context, IConfiguration  config)
        {
            _context = context;
            apiKey = config.GetValue<string>("APIKey");
        }

        // GET: NewProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: NewProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: NewProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,Name,Description,Price,Quantity,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: NewProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: NewProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,Name,Description,Price,Quantity,Category")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: NewProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: NewProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }

        public async Task<IActionResult> GetMovie(string title)
        {
            HttpClient client = new HttpClient();
            string url = $"http://www.omdbapi.com/?apikey={apiKey}&t={title}";
            var response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject(data).ToString();
            dynamic omdbMovie = JObject.Parse(json);
            ViewData["Json"] = json;
            var movieProduct = new Product
            {
                ProductID = 123,
                Name = omdbMovie["Title"],
                Category = omdbMovie["Genre"],
                Description = omdbMovie["Actors"],
                Price = 10m,
                Quantity = 5
            };
            ViewData["Poster"] = omdbMovie["Poster"];
            return View("Details", movieProduct);

        }

    }
}
