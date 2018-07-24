using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2_ViewBagPassingCToV.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Name = "Chandrahas Poojari";
            ViewBag.Birthday = DateTime.Parse("7/7/1988");
            ViewBag.IsMarried = true;
            ViewBag.Salary = 5000000000000000000;

            return View();
        }
    }
}