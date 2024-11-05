using System.Diagnostics;

namespace ThreadTask
{
    internal class Program
    {
        static object Lock = new object();
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            List<string> urls = new List<string>()
{
    "https://learn.microsoft.com/en-us/dotnet/standard/collections/when-to-use-generic-collections",
    "https://learn.microsoft.com/en-us/dotnet/standard/collections/",
    "https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-8.0",
    "https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/collections"
};          sw.Start();

            RetreaveDataAsync(urls);
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Restart();
            RetreaveData(urls).Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);
          

        }

        public static void  RetreaveDataAsync(List<string> urls)
        {
            HttpClient httpClient = new HttpClient();
            foreach (string url in urls)
            {

               Console.WriteLine(httpClient.GetStringAsync(url).Result.ToString());

            }



        }
        public static async Task RetreaveData(List<string> urls)
        {
            HttpClient httpClient = new HttpClient();
            List<Task<string>> strings=new List<Task<string>>();
            foreach (string url in urls)
            {
                strings.Add(httpClient.GetStringAsync(url));
                

            }
            await Task.WhenAll(strings);



        }
    }

   
}


