using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stankin.Connect.Models
{
    public static class Test3List
    {
        public static List<Test3> test3ar { get; set; } = new List<Test3>();

        public static void ReadFromFile()
        {
            try
            {
                string inputjson = File.ReadAllText("tests3.json");
                test3ar = JsonSerializer.Deserialize<List<Test3>>(inputjson);
            }
            catch (Exception e)
            { };
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("tests3.json", FileMode.OpenOrCreate))
            {

                JsonSerializer.SerializeAsync<List<Test3>>(fs, test3ar);
                Console.WriteLine("Data has been saved to file");
            }
        }
    }
}
