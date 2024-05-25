using System;
using System.Net.Http;
using System.Threading.Tasks;
using LogConverter.Core.Interfaces;

namespace LogConverter.App
{
    internal class FileDownloader : IFileDownloader
    {
        public async Task<string> DownloadFileAsync(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Failed to download content from {url}. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
