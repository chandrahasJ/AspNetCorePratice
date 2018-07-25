using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project2_ViewBagObjectList_CtoV.Models;

namespace Project2_ViewBagObjectList_CtoV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Product product = new Product()
                {
                    ID = i,
                    ProductName = "Product_" + i.ToString(),
                    ProductPrice = 10 * i
                };
                productList.Add(product);
            }

            ViewBag.ProductList = productList;
            return View();
        }
    }
}