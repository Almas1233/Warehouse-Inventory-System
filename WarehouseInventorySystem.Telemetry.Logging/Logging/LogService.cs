using WarehouseInventorySystem.Telemetry.Logging.Common;
using WarehouseInventorySystem.Telemetry.Logging.Enums;

namespace WarehouseInventorySystem.Telemetry.Logging.Logging;

public class LogService : ILogService
{
    private readonly ILogSink _logSink;

    public LogService(ILogSink logSink)
    {
        _logSink = logSink;
    }

    public void Log(
        LogLevel level, 
        string message, 
        Exception? exception = null
    )
    {
        var logEvent = new LogEvent(
            message, 
            DateTime.UtcNow, 
            level,
            exception
        );
        
        _logSink.Emit(logEvent);
    }

    public void LogInformation(string message)
    {
        var logEvent = new LogEvent(
            message,
            DateTime.UtcNow,
            LogLevel.Information
        );
        
        _logSink.Emit(logEvent);
    }
    
    public void LogWarning(string message)
    {
        var logEvent = new LogEvent(
            message,
            DateTime.UtcNow,
            LogLevel.Warning
        );
        
        _logSink.Emit(logEvent);
    }

    public void LogError(
        string message, 
        Exception exception
    )
    {
        var logEvent = new LogEvent(
            message,
            DateTime.UtcNow,
            LogLevel.Error,
            exception
        );

        _logSink.Emit(logEvent);
    }
}