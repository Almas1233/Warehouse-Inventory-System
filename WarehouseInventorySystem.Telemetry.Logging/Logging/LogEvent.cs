using WarehouseInventorySystem.Telemetry.Logging.Enums;

namespace WarehouseInventorySystem.Telemetry.Logging.Logging;

public class LogEvent
{
    public LogLevel? Level { get; }
    public string Message { get; }
    public DateTime Time { get; }
    public Exception? Exception { get; }
    
    public LogEvent(
        string message, 
        DateTime time, 
        LogLevel? level = null,
        Exception? exception = null
    )
    {
        Message = message;
        Time = time;
        Exception = exception;
        Level = level;
    }
}