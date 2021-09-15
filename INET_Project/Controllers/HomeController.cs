using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using INET_Project.Models;
using System.Text.RegularExpressions;

namespace INET_Project.Controllers
{
    public class HomeController : Controller
    {

        public static ProductModel Premiere { get; set; }

        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static List<ProductModel> Products { get; set; }
        public static ShippingDetail LocalOrder { get; set; }

        public IActionResult Main_Page(string search, int page = 1)
        {

            using (var context = new INETContext())
            {


                Products = context.Product
                .Join(context.ProductPicture,
                product => product.ProductID,
                productPicture => productPicture.ProductID,
               (product, productPicture) => new ProductModel { Product = product, ProductPicture = productPicture }).ToList();

                Premiere = Products.FirstOrDefault().Copy();
                Premiere.Product.ProductName = "Loudium Grass3 Computer Keyboard";

                ViewBag.CurrentPage = page < 1 ? 1 : page;

                var currentPage = (int)ViewBag.CurrentPage;



                if (String.IsNullOrEmpty(search))
                {
                    var forPagination = Products.Skip((currentPage - 1) * 10).Take(10);
                    return View(forPagination);
                }
                else
                {
                    var filterSearch = Products.Where(x => x.Product.ProductName.ToUpper().Contains(search.ToUpper()));
                    return View(filterSearch);
                }


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

        public IActionResult Product_Page()
        {
            return View("Product_Page");
        }


        public IActionResult Replacements()
        {
            return View("Replacements");
        }

        [HttpPost("Home/Replacements")]
        public async Task<IActionResult> ReplacementsAsync(ReturnDetail returnDetail)
        {

            Regex rgxName = new Regex("^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]");

            Regex rgxId = new Regex("^[0-9]");

            if (returnDetail.DateOfPurchase > returnDetail.DateOfReceiving || (returnDetail.DateOfPurchase > DateTime.Now || returnDetail.DateOfReceiving > DateTime.Now))
            {
                ModelState.AddModelError(nameof(returnDetail.DateOfPurchase), "Data zakupu nie może być późniejsza niż data otrzymania lub data aktualna. ");
                return View();
            }
            else if (!rgxName.IsMatch(returnDetail.FirstName))
            {
                ModelState.AddModelError(nameof(returnDetail.FirstName), "Imię może składać się z samych liter. ");
                return View();
            }
            else if (!rgxId.IsMatch(Convert.ToString(returnDetail.OrderId)))
            {
                ModelState.AddModelError(nameof(returnDetail.OrderId), "Id składa się z samych cyfr. ");
                return View();
            }
            else if (!rgxName.IsMatch(returnDetail.LastName))
            {

                ModelState.AddModelError(nameof(returnDetail.LastName), "Nazwisko może składać się z samych liter. ");
                return View();
            }
            else
            {
                //using (var context = new INETContext())
                //{
                //    context.ReturnDetail.Add(new ReturnDetail
                //    {
                //        OrderId = returnDetail.OrderId,
                //        FirstName = returnDetail.FirstName,
                //        LastName = returnDetail.LastName,
                //        DateOfPurchase = returnDetail.DateOfPurchase,
                //        DateOfReceiving = returnDetail.DateOfReceiving,
                //        ProductName = returnDetail.ProductName,
                //        Description = returnDetail.Description,
                //    });

                //    context.SaveChanges();
                //}

                return RedirectToAction(nameof(Main_Page));

            }

        }

        public IActionResult Order()
        {
            return View("Order");
        }

        [HttpPost]
        public async Task<IActionResult> Order(ShippingDetail shipping)
        {
            LocalOrder = shipping;

            Regex rgxName = new Regex("^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ]");

            if (!rgxName.IsMatch(shipping.Client.FirstName))
            {
                ModelState.AddModelError(nameof(shipping.Client.FirstName), "Imię może składać się z samych liter. ");
                return View();
            }
            else if (!rgxName.IsMatch(Convert.ToString(shipping.Client.SecondName)))
            {
                ModelState.AddModelError(nameof(shipping.Client.SecondName), "Nazwisko może składać się z samych liter. ");
                return View();
            }


            return RedirectToAction(nameof(Summary));
        }

        public IActionResult Summary(ShippingDetail shipping)
        {
            shipping = LocalOrder;

            var products = Products;
            var prize = products.FirstOrDefault().Product.UnitPrice;
            var quantity = LocalOrder.OrderDetail.Quantity;
            double payment = Math.Round((double)(quantity * prize), 2);

            if (LocalOrder.TypeOfOrder == 0)
            {
                payment = payment + 25;
            }

            LocalOrder.OrderDetail.UnitPrice = prize;

            shipping = LocalOrder;

            using (var context = new INETContext())
            {
                if (!(context.Client.Select(x => x.EmailAddress).Contains(LocalOrder.Client.EmailAddress)))
                {
                    context.Client.Add(new Client
                    {
                        FirstName = shipping.Client.FirstName,
                        SecondName = shipping.Client.SecondName,
                        City = shipping.Client.City,
                        Country = shipping.Client.Country,
                        Street = shipping.Client.Street,
                        EmailAddress = shipping.Client.EmailAddress,
                        BuildingNumber = shipping.Client.BuildingNumber,
                        Login = shipping.Client.FirstName,
                        Password = shipping.Client.SecondName
                    });
                }

                context.SaveChanges();


                var clientID = context.Client.Select(x => x.ClientID).Max();

                context.Order.Add(new Order
                {
                    ClientID = clientID,
                    PreparedDate = DateTime.Now,
                    SentToAddress = $"{shipping.Client.City}, {shipping.Client.Street} {shipping.Client.BuildingNumber}, {shipping.Client.Country}",
                    IsInvoiced = true

                });

                context.SaveChanges();


                context.OrderDetail.Add(new OrderDetail
                {
                    OrderID = context.Order.OrderBy(o => o.OrderID).LastOrDefault().OrderID,
                    Quantity = shipping.OrderDetail.Quantity,
                    UnitPrice = shipping.OrderDetail.UnitPrice,
                    ProductID = Products.Select(x => x.Product.ProductID).Last()
                }) ;

                context.SaveChanges();

                var produktID = context.Product.Where(x => x.ProductID == Products.Select(x => x.Product.ProductID).LastOrDefault());


                foreach (var item in produktID)
                {
                    item.QtAvailable = item.QtAvailable - 1;
                }

                context.SaveChanges();

            }
            return View("Summary", LocalOrder);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
