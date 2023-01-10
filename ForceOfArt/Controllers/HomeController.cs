using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ForceOfArt.Models;
using DB;

namespace ForceOfArt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var factory = new JsonExtractorFactory("C:\\Users\\uzver\\SmallArtBase\\collection\\objects");
            //var processor =  factory.GetProcessor();
            //processor.Process();
            //var objects = processor.GetData();
            //var con = new DbConnection();
            //con.CreateDB();
            //con.FillData(objects);
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
