using LogConverter.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogConverter.Infrastructure.Services
{
    public class FileDownloader : IFileDownloader
    {
        public async Task<string> DownloadFileAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }
    }
}

