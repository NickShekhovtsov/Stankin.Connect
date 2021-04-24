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
            string inputjson=File.ReadAllText("user.json");
            classes = JsonSerializer.Deserialize<List<Class>>(inputjson);
           
        }

        public static void WriteToFile()
        {
            using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
            {
                 
                 JsonSerializer.SerializeAsync<List<Class>>(fs, classes);
                Console.WriteLine("Data has been saved to file");
            }
        }
        static ClassArray()
        {
            //string inputjson="";
            //classes = JsonSerializer.Deserialize<List<Class>>(inputjson);
            classes.Add(new Class { id = 15, id2 = 16 });
            classes.Add(new Class { id = 17, id2 = 18 });
            classes.Add(new Class { id = 19, id2 = 20 });
        }
    }
}
