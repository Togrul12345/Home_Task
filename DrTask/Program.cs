using Newtonsoft.Json;
using System.Net.Http.Json;

namespace DrTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //   string path = @"C:\Users\Togrul\source\repos\DrTask\DrTask";
         //   Directory.CreateDirectory(path + @"\Model");
         //   Directory.CreateDirectory(path + @"\Data");
         //File.Create(path + @"\Data" + " jsonData.json");
            HttpClient httpClient = new HttpClient();
            string newPath = "https://jsonplaceholder.typicode.com/posts";
            str= httpClient.GetStringAsync(newPath).Result.;
            
           
          


        }
    }
}
