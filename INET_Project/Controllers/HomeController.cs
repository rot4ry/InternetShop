using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using INET_Project.Models;

namespace INET_Project.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Main_Page(int page = 1)
        {

            using (var context = new INETContext())
            {

                   var products = context.Product
                    .Join(context.ProductPicture,
                    product => product.ProductID,
                    productPicture => productPicture.ProductID,
                   (product, productPicture) => new ProductModel{ Product = product, ProductPicture = productPicture });

                ViewBag.CurrentPage = page < 1 ? 1 : page;

                var currentPage = (int)ViewBag.CurrentPage;

                var forPage = products.ToList().Skip((currentPage-1)*10).Take(10);

                return View(forPage);
            }
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Cart()
        {
            return View("Cart");
        }

        public IActionResult Index()
        {
            return View("Main_Page");
        }

        public IActionResult About()
        {
            return View("About");
        }
        
        public IActionResult Contact()
        {
            return View("Contact");
        }

        public IActionResult Privacy()
        {
            return View("Privacy");
        }

        public IActionResult Replacements()
        {
            return View("Replacements");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
