using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stankin.Connect.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Stankin.Connect.Controllers
{
    public class HomeController : Controller
    {
        Class a = new Class();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            ClassArray.ReadFromFile();
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            Class a = new Class();
            ClassArray.WriteToFile();
            ClassArray.ReadFromFile();
            return View(a);
        }

        public IActionResult Add(Class cl)
        {
            //cl.id = 15;
            // string js=JsonSerializer.Serialize(cl);
            ClassArray.classes.Add(cl);
            ClassArray.WriteToFile();
            return RedirectToAction("Privacy");
        }
        
        public IActionResult Privacy()
        {
            
            return View();
        }

        public IActionResult Res(Class cl)
        {
            Console.WriteLine(cl.id2); ;
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult AddList()
        {
            a.id = 15;
            return RedirectToAction("Index");
        }
    }
}
