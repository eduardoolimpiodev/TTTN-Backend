using System;
using System.IO;
using System.Threading.Tasks;
using LogConverter.Infrastructure.Services;
using LogConverter.Core.Interfaces; 
using LogConverter.Core.Services;
using LogConverter.Infrastructure.Services;


namespace LogConverter.App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            string outputPath = @"C:\testeTTTN\outputTest.txt";

            IFileDownloader downloader = new FileDownloader() as IFileDownloader;
            if (downloader == null)
            {
                throw new InvalidCastException("FileDownloader is not implementing IFileDownloader properly.");
            }
            ILogParser parser = new LogParserService();
            ILogFormatter formatter = new LogFormatterService();

            try
            {
                var logContent = await downloader.DownloadFileAsync(url);
                var logEntries = parser.ParseLogs(logContent);
                var formattedContent = formatter.FormatLogs(logEntries);
                File.WriteAllText(outputPath, formattedContent);
                Console.WriteLine("Log file downloaded and processed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}



//using System;
//using System.IO;
//using System.Threading.Tasks;
//using LogConverter.Core.Interfaces;
//using LogConverter.Core.Services;
//using LogConverter.Infrastructure.Services;

//namespace LogConverter.App
//{
//    class Program
//    {
//        static async Task Main(string[] args)
//        {
//            if (args.Length != 2)
//            {
//                Console.WriteLine("Usage: LogConverter.App <sourceUrl> <targetPath>");
//                return;
//            }

//            FileDownloader downloader = new FileDownloader();
//            ILogParser parser = new LogParserService();  // Certifique-se de que está usando a instância correta
//            ILogFormatter formatter = new LogFormatterService();  // Certifique-se de que está usando a instância correta

//            try
//            {
//                var content = await downloader.DownloadFileAsync(args[0]);
//                var entries = parser.ParseLogs(content);
//                var formatted = formatter.FormatLogs(entries);
//                File.WriteAllText(args[1], formatted);
//                Console.WriteLine("Log file converted successfully.");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error: {ex.Message}");
//            }
//        }
//    }
//}
