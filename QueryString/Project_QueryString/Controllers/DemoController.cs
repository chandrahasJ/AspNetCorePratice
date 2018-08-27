using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project_QueryString.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("Demo2")]
        public IActionResult Demo2(
            [FromQuery(Name = "id")] string id1 //Data will be extracted from Query
        )
        {
            ViewBag.ID = id1;

            return View("Demo2");
        }

        [Route("Demo3")]
        public IActionResult Demo3(
            [FromQuery(Name = "Data1")] string Data1,
            [FromQuery(Name = "Data2")] string NameString
            )
        {
            ViewBag.Data1 = Data1;
            ViewBag.Data2 = NameString;

            return View("Demo3");
        }

        [Route("Demo4")]
        public IActionResult Demo4()
        {
            var id1 = int.Parse(HttpContext.Request.Query["id1"].ToString());
            var id2 = HttpContext.Request.Query["id2"].ToString();
            ViewBag.ID1 = id1;
            ViewBag.ID2 = id2;

            return View("Demo4");
        }
    }
}