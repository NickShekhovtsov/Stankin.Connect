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
    }
}
