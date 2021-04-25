using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stankin.Connect.Models
{
    public static class Test2List
    {
        public static List<Test2> test2ar { get; set; } = new List<Test2>();
        
        public static void ReadFromFile()
        {
            try
            {
                string inputjson = File.ReadAllText("tests2.json");
                test2ar = JsonSerializer.Deserialize<List<Test2>>(inputjson);
            }
            catch (Exception e)
            { };
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("tests2.json", FileMode.OpenOrCreate))
            {

                JsonSerializer.SerializeAsync<List<Test2>>(fs, test2ar);
                Console.WriteLine("Data has been saved to file");
            }
        }

        public static void GenerateExcel()
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo("myWorkbook1.xlsx");
            using (var package = new ExcelPackage(file))
            {
                ExcelWorksheet sheet;
                if (package.Workbook.Worksheets.Count() == 0)
                {
                    package.Workbook.Worksheets.Add("Test1");
                    var sheett = package.Workbook.Worksheets.Add("Test2");
                    sheett.Cells["A1"].Value = "";
                    sheet = sheett;
                }
                else
                {
                    if (package.Workbook.Worksheets.Count() == 1)
                    {
                        var sheett = package.Workbook.Worksheets.Add("Test2");
                        sheet = sheett;
                    }
                    else
                    {
                        var sheett = package.Workbook.Worksheets[1];
                        sheet = sheett;
                    }
                }
                sheet.Column(1).Width = 30;
                sheet.Column(7).Width = 40;
                for (int i = 1; i < Test2List.test2ar.Count() + 1; i++)
                {
                    sheet.Cells[i + 1, 1].Value = "Респондент" + i;
                }

                for (int i = 1; i < 6; i++)
                {
                    sheet.Cells[1, i + 1].Value = "В" + i;
                }

                for (int i = 0; i < Test2List.test2ar.Count(); i++)
                {


                    if (Test2List.test2ar[i].radio1 == 0)
                        sheet.Cells[i + 2, 2].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 2].Value = "Да";
                    }

                    if (Test2List.test2ar[i].radio2 == 0)
                        sheet.Cells[i + 2, 3].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 3].Value = "Да";
                    }

                    if (Test2List.test2ar[i].radio3 == 0)
                        sheet.Cells[i + 2, 4].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 4].Value = "Да";
                    }

                    if (Test2List.test2ar[i].radio4 == 0)
                        sheet.Cells[i + 2, 5].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 5].Value = "Да";
                    }

                    if (Test2List.test2ar[i].radio5 == 0)
                        sheet.Cells[i + 2, 6].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 6].Value = "Да";
                    }

                    

                    sheet.Cells[i + 2, 7].Value = Test2List.test2ar[i].mail;
                    sheet.Cells[1, 7].Value = "Электронная почта";


                }
                sheet.Cells["A1"].Value = "";


                package.Save();
            }


        }


    }
}
