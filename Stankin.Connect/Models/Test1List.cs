using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Stankin.Connect.Models
{
    public  static class Test1List
    {
        public static  List<Test1> test1ar { get; set; } = new List<Test1>();
        public static void ReadFromFile()
        {
            try
            {
                string inputjson = File.ReadAllText("test1.json");
                test1ar = JsonSerializer.Deserialize<List<Test1>>(inputjson);
            }
            catch(Exception e)
            { };
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("test1.json", FileMode.OpenOrCreate))
            {
                 
                 JsonSerializer.SerializeAsync<List<Test1>>(fs, test1ar);
                Console.WriteLine("Data has been saved to file");
            }
        }
        
    }
}
