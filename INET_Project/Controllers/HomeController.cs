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

        public IActionResult Main_Page()
        {
            return View();
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
