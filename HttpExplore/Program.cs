using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            var analyzer = new SiteAnalyzer(Client);
            var size = analyzer.GetContentSize("http://microsoft.com").Result;
            Console.WriteLine($"Size: {size}");
            Console.ReadLine();
        }

        private static readonly HttpClient Client = new HttpClient(); // Singleton
    }
}
