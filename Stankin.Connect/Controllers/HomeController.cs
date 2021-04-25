using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stankin.Connect.Models;
using System.Diagnostics;
using System.Linq;
using System.IO;
using OfficeOpenXml;
using System;

namespace Stankin.Connect.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            Test1List.ReadFromFile();
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Test1()
        {
            return View();
        }

        public IActionResult Test2()
        {
            return View();
        }

        public IActionResult Test3()
        {
            return View();
        }
        public IActionResult Support()
        {
            return View();
        }

        public IActionResult Authorization()
        {
            return View();
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult AddMessageToAdmin(ContactToAdmin contactToAdmin)
        {
            ContactToAdminArray.ReadFromJson();
            if (contactToAdmin.mail != null && contactToAdmin.text != null)
            {
                ContactToAdminArray.contactToAdmins.Add(contactToAdmin);
                ContactToAdminArray.WriteToJson();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AdminAccount()
        {
            ContactToAdminArray.ReadFromJson();
            return View(ContactToAdminArray.contactToAdmins);
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        [HttpPost]
        public IActionResult CheckAuthorization(Account acc)
        {
            if (acc.login == "admin" && acc.password == "0000")
                return RedirectToAction("AdminPanel");
            else
            {
                if (acc.login == "Oleg" && acc.password == "Nick")
                    return RedirectToAction("AdminPanel");

                else
                {
                    return View("Authorization");
                }
            }
        }
        public IActionResult Test1Add(Test1 t1)
        {
            Test1List.test1ar.Add(t1);
            Test1List.WriteToFile();
            return View("Index");
        }
        public IActionResult Test2Add(Test2 t2)
        {
            Test2List.test2ar.Add(t2);
            Test2List.WriteToFile();
            return View("Index");
        }

        public IActionResult Test3Add(Test3 t3)
        {
            Test3List.test3ar.Add(t3);
            Test3List.WriteToFile();
            return View("Index");
        }
        
        public FileResult GetExcelFile()
        {

            Test1List.GenerateExcel();
            Test2List.GenerateExcel();
            Test3List.GenerateExcel();
                string path = "myWorkbook1.xlsx";
                byte[] mas = System.IO.File.ReadAllBytes(path);
                string file_type = "application/xlsx";
                string file_name = "Report.xlsx";
                return File(mas, file_type, file_name);
            
            
            

          
        }

        
    }

}
