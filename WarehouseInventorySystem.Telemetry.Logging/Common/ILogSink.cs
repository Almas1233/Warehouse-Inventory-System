using WarehouseInventorySystem.Telemetry.Logging.Logging;

namespace WarehouseInventorySystem.Telemetry.Logging.Common;

public interface ILogSink
{
    void Emit(LogEvent logEvent);
}