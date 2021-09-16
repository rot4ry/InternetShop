using System;
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

        private static List<DemoProduct> _demoProducts = new List<DemoProduct>();

        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Dashboard(ProductModel productModel, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                using (var context = new INETContext())
                {

                    HomeController.AllOrders = context.Order.ToList();

                    context.Product.Add(new Product
                    {
                        ProductName = productModel.Product.ProductName,
                        ProductDescription = productModel.Product.ProductDescription,
                        UnitPrice = productModel.Product.UnitPrice,
                        QtAvailable = productModel.Product.QtAvailable,
                        Brand = productModel.Product.Brand,
                        ProducerCode = productModel.Product.ProducerCode

                    });


                    var productID = context.Product.Select(x => x.ProductID).Max();

                    string wwwRootPath = "E:/Users/denn/Documents/GitHub/InternetShop/INET_Project/wwwroot";
                    var filePath = Path.Combine(wwwRootPath + "/Resources/", picture.FileName);
                    var databasePath = Path.Combine("Resources/", picture.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        picture.CopyToAsync(stream);
                    }


                    context.ProductPicture.Add(new ProductPicture
                    {
                        ProductID = productID,
                        PicturePath = databasePath

                    });

                    context.SaveChanges();
                }
                return RedirectToAction(nameof(Dashboard));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Products()
        {
            HomeController.UpdateProducts();
            return View(HomeController.Products);
        }

        [HttpGet]
        public IActionResult Orders()
        {
            using (var context = new INETContext())
            {
                return View(context.Order.ToList());
            }
        }

        [HttpGet]
        public IActionResult Categories()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(Product product)
        {
            using (var context = new INETContext())
            {

                var local = HomeController.Products.Select(x => x.Product.ProductID).FirstOrDefault();

                var editedProduct = context.Product.Where(x => x.ProductID == local).FirstOrDefault();

                if (product.ProductName != null)
                {
                    editedProduct.ProductName = product.ProductName;
                }
                else if (product.Brand != null)
                {
                    editedProduct.Brand = product.Brand;
                }
                else if (product.QtAvailable != 0)
                {
                    editedProduct.QtAvailable = product.QtAvailable;
                }
                else if (product.UnitPrice != 0)
                {
                    editedProduct.UnitPrice = product.UnitPrice;
                }
                else if (product.ProducerCode != null)
                {
                    editedProduct.ProducerCode = product.ProducerCode;
                }
                else if (product.ProductDescription != null)
                {
                    editedProduct.ProductDescription = product.ProductDescription;
                }

                context.SaveChanges();
            }
            return RedirectToAction(nameof(Products));
        }


        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAsync()
        {
            using (var context = new INETContext())
            {
                var local = HomeController.Products.Select(x => x.Product.ProductID).FirstOrDefault();

                var editedProduct = context.Product.Where(x => x.ProductID == local).FirstOrDefault();

                context.Remove(editedProduct);

                context.SaveChanges();
            }
            return RedirectToAction(nameof(Products));
        }

        //public async Task UploadFile(IFormFile file)
        //{
        //    if (file == null)
        //    {
        //        HttpContext.Session.GetString("ImageName");
        //        return;
        //    }

        //    var uniqueName = $"{Guid.NewGuid()}_{file.FileName}";
        //    HttpContext.Session.SetString("ImageName", uniqueName);

        //    // var toFolder = Path.Combine(_environment.WebRootPath, "images");
        //    var filePath = Path.Combine(toFolder, uniqueName);

        //    using var fileStream = new FileStream(filePath, FileMode.Create);
        //    await file.CopyToAsync(fileStream);
        //}

    }
}
