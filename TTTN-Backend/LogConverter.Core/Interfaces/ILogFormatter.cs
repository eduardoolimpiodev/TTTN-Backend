using LogConverter.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogConverter.Core.Interfaces
{
    public interface ILogFormatter
    {
        string FormatLogs(IEnumerable<LogEntry> entries);
    }
}
