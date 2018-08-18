using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RouteWithParameter.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("MyDemoPage")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("demo2/{id}")]
        [Route("cj/{id}")]
        public IActionResult Demo2(int id)
        {
            ViewBag.id = id;
            return View("Demo2");
        }

        [Route("demo3/{id1}/{id2}")]
        [Route("cc/{id1}/{id2}")]
        public IActionResult Demo3(int id1,string id2)
        {
            ViewBag.id = id1;
            ViewBag.id2 = id2;
            return View("Demo3");
        }
    }
}