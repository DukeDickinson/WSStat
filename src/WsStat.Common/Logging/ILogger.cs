using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WSStat.Common.Logging
{
    public enum Category
    {
        General,
        Data,
        Model,
        UI
    };

    public interface ILogger
    {
        void Critical(string message, Exception ex, Category category);
        void Error(string message, Exception ex, Category category);
        void Warning(string message, Category category);
        void Information(string message, Category category);
    }
}
