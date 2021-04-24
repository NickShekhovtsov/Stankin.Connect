using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stankin.Connect.Models
{
    public static class ContactToAdminArray
    {
        public static List<ContactToAdmin> contactToAdmins { get; set; } = new List<ContactToAdmin>();
        public static void WriteToJson()
        {
            using (FileStream fs = new FileStream("ContactToAdmin.json", FileMode.OpenOrCreate))
            {

                JsonSerializer.SerializeAsync<List<ContactToAdmin>>(fs, contactToAdmins);
                Console.WriteLine("Data has been saved to file");
            }
        }


        public static void ReadFromJson()
        {
            try {
                string inputjson = File.ReadAllText("ContactToAdmin.json");
                contactToAdmins = JsonSerializer.Deserialize<List<ContactToAdmin>>(inputjson);
            }
            catch(Exception e)
            { }
            }
    }
}
