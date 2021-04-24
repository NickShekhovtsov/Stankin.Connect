using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stankin.Connect.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml;
//using OfficeOpenXml;
using System.IO;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
//using Grpc.Core;
//using System.Web.Mvc;

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

            //ClassArray.WriteToFile();
            return View(a);
        }

        public IActionResult Add(Class cl)
        {
            //cl.id = 15;
            // string js=JsonSerializer.Serialize(cl);
            ClassArray.classes.Add(cl);
            ClassArray.WriteToFile();
            GenerateExel();
            return View("Index");
        }

        public IActionResult Privacy()
        {

            return View();
        }

        public IActionResult Test1()
        {
            return View();
        }
        public IActionResult Support()
        {
            

            return View();
        }

        public IActionResult Sup(ContactToAdmin contactToAdmin)
        {
            ContactToAdminArray.ReadFromJson();
            ContactToAdminArray.contactToAdmins.Add(contactToAdmin);
            ContactToAdminArray.WriteToJson();
            return RedirectToAction("Index");
        }

        public IActionResult Info()
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
        public void GenerateExel()
        {
            
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo("myWorkbook1.xlsx");
            using (var package = new ExcelPackage(file))
            {
                if (package.Workbook.Worksheets.Count() == 0)
                {
                    var sheet = package.Workbook.Worksheets.Add("My Sheet");
                    sheet.Cells["A1"].Value = "Hello World123!";
                }
                else
                {
                   
                    var sheet = package.Workbook.Worksheets[0];

                    sheet.Column(1).Width = 30;
                    for (int i = 1; i < ClassArray.classes.Count()+1; i++)
                    {
                        sheet.Cells[i+1, 1].Value = "Респондент" + i;
                    }

                    for (int i = 1; i <7; i++)
                    {
                        sheet.Cells[1, i+1].Value = "В"+i;
                    }

                    for (int i=0;i<ClassArray.classes.Count();i++)
                    {

                        
                            if (ClassArray.classes[i].radio1 == 0)
                                sheet.Cells[i + 2,2].Value = "Нет";
                            else
                            {
                                sheet.Cells[i + 2,2].Value = "Да";
                            }

                        if (ClassArray.classes[i].radio2 == 0)
                            sheet.Cells[i + 2, 3].Value = "Нет";
                        else
                        {
                            sheet.Cells[i + 2, 3].Value = "Да";
                        }

                        if (ClassArray.classes[i].radio3 == 0)
                            sheet.Cells[i + 2, 4].Value= "Нет";
                        else
                        {
                            sheet.Cells[i + 2, 4].Value = "Да";
                        }

                        if (ClassArray.classes[i].radio4 == 0)
                            sheet.Cells[i + 2, 5].Value = "Нет";
                        else
                        {
                            sheet.Cells[i + 2, 5].Value = "Да";
                        }

                        if (ClassArray.classes[i].radio5 == 0)
                            sheet.Cells[i + 2, 6].Value = "Нет";
                        else
                        {
                            sheet.Cells[i + 2, 6].Value = "Да";
                        }

                        if (ClassArray.classes[i].radio6 == 0)
                            sheet.Cells[i + 2, 7].Value = "Нет";
                        else
                        {
                            sheet.Cells[i + 2, 7].Value = "Да";
                        }


                    }
                    
                }
                ////var sheet = package.Workbook.Worksheets.Add("My Sheet");
                ////sheet.Cells["A1"].Value = "Hello World!";

                // Save to file
                package.Save();
            }
            

        }

        public FileResult GetFile()
        {
            string path = "myWorkbook1.xlsx";
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "application/xlsx";
            string file_name = "Report.xlsx";

            return File(mas, file_type, file_name);

          
        }

        public IActionResult Admin()
        {
            return View();
        }
    }

}
