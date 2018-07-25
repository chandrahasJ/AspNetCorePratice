using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3_ViewBag_Object_CToV.Models;

namespace Project3_ViewBag_Object_CToV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product product = new Product()
            {
                ID = 1,
                ProductName = "Phone",
                ProductDescription = "Honor",
                ProductPrice = 9546
            };

            ViewBag.Product = product;
            return View();
        }
    }
}