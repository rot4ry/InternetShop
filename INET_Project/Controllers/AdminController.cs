﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using INET_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INET_Project.Controllers
{
    public class AdminController : Controller
    {
        private IWebHostEnvironment _environment;
        private static List<DemoProduct> _demoProducts = new List<DemoProduct>();
        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [HttpGet]
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
                var imageName = HttpContext.Session.GetString("ImageName");
                if (!string.IsNullOrEmpty(imageName))
                {
                    products.ProductImage = imageName;
                    HttpContext.Session.SetString("ImageName", "");
                }
                _demoProducts.Add(products);
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Products()
        {
            ViewBag.Products = _demoProducts;
            return View();
        }
        [HttpGet]
        public IActionResult Orders()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Categories()
        {
            return View();
        }
        public async Task UploadFile(IFormFile file)
        {
            if (file == null)
            {
                HttpContext.Session.GetString("ImageName");
                return;
            }

            var uniqueName = $"{Guid.NewGuid()}_{file.FileName}";
            HttpContext.Session.SetString("ImageName", uniqueName);

            var toFolder = Path.Combine(_environment.WebRootPath, "images");
            var filePath = Path.Combine(toFolder, uniqueName);

            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
    }
}
