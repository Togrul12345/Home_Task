using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace DirectoryTask
{
    internal class Program
    {
        static  async Task Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            string path = "https://jsonplaceholder.typicode.com/posts";

            string path2 = @"C:\Users\Togrul\OneDrive\Masaüstü\source\repos\DirectoryTask\DirectoryTask";
            DirectoryInfo directory = Directory.CreateDirectory(path2 + @"\Model");
            directory.Create();
            DirectoryInfo directory2 = Directory.CreateDirectory(path2 + @"\Data");
            directory.Create();
            FileStream fs = File.Create(path2 + @"\Model\Data.Json");
            string json = await httpClient.GetStringAsync(path);
           object? deSerializad= JsonConvert.DeserializeObject(json);
            string serialized= JsonConvert.SerializeObject(deSerializad,Formatting.Indented);
            
            
           

            StreamWriter sw=new StreamWriter(fs);
            sw.WriteLine(serialized);
            sw.Close();






        }

        private static object GetStringAsync(string path)
        {
            throw new NotImplementedException();
        }
    }


}

