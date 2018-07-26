using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Project3_ReadAppConfig.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            var configurationData = builder.Build();

            ViewBag.results1 = configurationData["Message"];
            ViewBag.ConfigProperties1 = configurationData["MyConfigData:ConfigData1"];
            ViewBag.ConfigProperties2 = configurationData["MyConfigData:ConfigData2"];
            ViewBag.ConfigProperties3 = configurationData["MyConfigData:ConfigData3"];
            return View();
        }
    }
}