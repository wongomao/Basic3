using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpExplore
{
    public class SiteAnalyzer
    {
        public SiteAnalyzer(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetContentSize(string uri)
        {
            var response = await _httpClient.GetAsync(uri);
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            return content.Length;
        }

        private readonly HttpClient _httpClient;
    }
}
