using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stankin.Connect.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Stankin.Connect.Controllers
{
    public class HomeController : Controller
    {
        Class a = new Class();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            Class a = new Class();
           
            return View(a);
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

        public IActionResult AddList()
        {
            a.i = 15;
            return RedirectToAction("Index");
        }
    }
}
