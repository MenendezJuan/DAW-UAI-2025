using BE.Base;

namespace BE.Entities
{
    public class Log : BaseEntity
    {
        public string Module { get; set; }
        public string Message { get; set; }
        public LogType Type { get; set; }

    }

    public enum LogType
    {
        Info,
        Warning,
        Error,
        Critical
    }
}
