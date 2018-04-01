using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    public class CustomDownloader
    {
        public static async Task<string> DownloadUrlAsync(string urlString, CancellationToken token)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlString, token);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
