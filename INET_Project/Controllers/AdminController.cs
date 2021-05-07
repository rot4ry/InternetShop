using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INET_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace INET_Project.Controllers
{
    public class AdminController : Controller
    {
        private static List<DemoProduct> _demoProducts = new List<DemoProduct>();
        public IActionResult Dashboard()
        {
            ViewBag.Products = _demoProducts;
            return View();
        }
        [HttpPost]
        public IActionResult Dashboard(DemoProduct products)
        {
            if (ModelState.IsValid)
            {
                _demoProducts.Add(products);
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }
    }
}
