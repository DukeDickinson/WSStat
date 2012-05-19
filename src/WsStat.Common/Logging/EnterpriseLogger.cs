using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Diagnostics;

namespace WSStat.Common.Logging
{
    public class EnterpriseLogger : ILogger
    {
        public void Critical(string message, Exception ex, Category category)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            StringBuilder msg = new StringBuilder(message);
            msg.AppendLine(ex.Message);
            msg.AppendLine(ex.Source);
            msg.AppendLine(ex.StackTrace);

            Log(msg.ToString(), TraceEventType.Critical, category);
        }

        public void Error(string message, Exception ex, Category category)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            StringBuilder msg = new StringBuilder(message);
            msg.AppendLine(ex.Message);
            msg.AppendLine(ex.Source);
            msg.AppendLine(ex.StackTrace);

            Log(msg.ToString(), TraceEventType.Error, category);
        }

        public void Warning(string message, Category category)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            Log(message, TraceEventType.Warning, category);
        }

        public void Information(string message, Category category)
        {
            if (!Logger.IsLoggingEnabled())
                return;

            Log(message, TraceEventType.Information, category);
        }

        private static void Log(string message, TraceEventType severity, Category category)
        {
            string categoryName = Enum.GetName(typeof(Category), category);

            LogEntry entry = new LogEntry()
            {
                Message = message,
                Severity = severity,
                Categories = new List<string>() { categoryName },
            };

            Logger.Write(entry);
        }
    }
}
