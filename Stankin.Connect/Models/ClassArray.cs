using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Stankin.Connect.Models
{
    public  static class ClassArray
    {
        public static  List<Class> classes { get; set; } = new List<Class>();
        //public static ClassArray cl { get; set; } = new ClassArray();
        public static void ReadFromFile()
        {
            try
            {
                string inputjson = File.ReadAllText("user.json");
                classes = JsonSerializer.Deserialize<List<Class>>(inputjson);
            }
            catch(Exception e)
            { };
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                 
                 JsonSerializer.SerializeAsync<List<Class>>(fs, classes);
                Console.WriteLine("Data has been saved to file");
            }
        }
        
    }
}
