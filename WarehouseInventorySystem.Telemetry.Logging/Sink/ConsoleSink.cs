using WarehouseInventorySystem.Telemetry.Logging.Common;
using WarehouseInventorySystem.Telemetry.Logging.Logging;

namespace WarehouseInventorySystem.Telemetry.Logging.Sink;

public class ConsoleSink : ILogSink
{
    public void Emit(LogEvent logEvent)
    {
        Console.WriteLine(
            $"[{logEvent.Time}] " +
            $"[{logEvent.Level}] " +
            $"{logEvent.Message}"
        );
    }
}