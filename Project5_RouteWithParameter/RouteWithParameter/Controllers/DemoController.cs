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

        [Route("cc/{data1}/{data2}")]
        [Route("demo3/{data1}/{data2}")]        
        public IActionResult Demo3(int data1, string data2)
        {
            ViewBag.data1 = data1;
            ViewBag.data2 = data2;
            return View("Demo3");
        }
    }
}