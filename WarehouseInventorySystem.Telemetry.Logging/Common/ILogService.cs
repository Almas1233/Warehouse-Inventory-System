using WarehouseInventorySystem.Telemetry.Logging.Enums;

namespace WarehouseInventorySystem.Telemetry.Logging.Common;

public interface ILogService
{
    void Log(LogLevel level,string message, Exception? exception = null);
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message, Exception exception);
}