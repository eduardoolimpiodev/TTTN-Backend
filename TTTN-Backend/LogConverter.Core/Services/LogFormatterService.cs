using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogConverter.Core.Interfaces;
using LogConverter.Core.Models;

namespace LogConverter.Core.Services
{
    public class LogFormatterService : ILogFormatter
    {
        public string FormatLogs(IEnumerable<LogEntry> entries)
        {
            var header = "#Version: 1.0\n#Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n";
            return header + string.Join("\n", entries.Select(e => e.FormatAgora()));
        }

        
    }


}



