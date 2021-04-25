using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using OfficeOpenXml;

namespace Stankin.Connect.Models
{
    public  static class Test1List
    {
        public static  List<Test1> test1ar { get; set; } = new List<Test1>();
        public static void ReadFromFile()
        {
            try
            {
                string inputjson = File.ReadAllText("tests1.json");
                test1ar = JsonSerializer.Deserialize<List<Test1>>(inputjson);
            }
            catch(Exception e)
            { };
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("tests1.json", FileMode.OpenOrCreate))
            {
                 
                 JsonSerializer.SerializeAsync<List<Test1>>(fs, test1ar);
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
                    var sheett = package.Workbook.Worksheets.Add("Test1");
                    sheett.Cells["A1"].Value = "";
                    sheet = sheett;
                }
                else
                {

                    var sheett = package.Workbook.Worksheets[0];
                    sheet = sheett;
                }
                sheet.Column(1).Width = 30;
                sheet.Column(8).Width = 40;
                for (int i = 1; i < Test1List.test1ar.Count() + 1; i++)
                {
                    sheet.Cells[i + 1, 1].Value = "Респондент" + i;
                }

                for (int i = 1; i < 7; i++)
                {
                    sheet.Cells[1, i + 1].Value = "В" + i;
                }

                for (int i = 0; i < Test1List.test1ar.Count(); i++)
                {


                    if (Test1List.test1ar[i].radio1 == 0)
                        sheet.Cells[i + 2, 2].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 2].Value = "Да";
                    }

                    if (Test1List.test1ar[i].radio2 == 0)
                        sheet.Cells[i + 2, 3].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 3].Value = "Да";
                    }

                    if (Test1List.test1ar[i].radio3 == 0)
                        sheet.Cells[i + 2, 4].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 4].Value = "Да";
                    }

                    if (Test1List.test1ar[i].radio4 == 0)
                        sheet.Cells[i + 2, 5].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 5].Value = "Да";
                    }

                    if (Test1List.test1ar[i].radio5 == 0)
                        sheet.Cells[i + 2, 6].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 6].Value = "Да";
                    }

                    if (Test1List.test1ar[i].radio6 == 0)
                        sheet.Cells[i + 2, 7].Value = "Нет";
                    else
                    {
                        sheet.Cells[i + 2, 7].Value = "Да";
                    }

                    sheet.Cells[i + 2, 8].Value = Test1List.test1ar[i].mail;
                    sheet.Cells[1, 8].Value = "Электронная почта";


                }
                sheet.Cells["A1"].Value = "";


                package.Save();
            }


        }
    }
}
