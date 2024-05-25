using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogConverter.Infrastructure.Interfaces;


namespace LogConverter.Infrastructure.Interfaces
{
    public interface IFileDownloader
    {
        Task<string> DownloadFileAsync(string url);
    }
}
