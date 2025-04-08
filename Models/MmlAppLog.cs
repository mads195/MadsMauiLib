using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Mads195.MadsMauiLib.Models
{
    public class MmlAppLog
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }
        public string EntryText { get; set; }
        public string Detail { get; set; }
        public string Class { get; set; }
        public string Method { get; set; }
        public string CreatedAt { get; set; }
        public LogSeverity Severity { get; set; }
        public int LineNumber { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionType { get; set; }
        public string InnerException { get; set; }
        public string ErrorCode { get; set; }
    }
    public enum LogSeverity
    {
        Debug,
        Info,
        Warn,
        Error
    }
}
