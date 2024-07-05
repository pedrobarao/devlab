using Lab.Telemetry.Interfaces;

namespace Lab.Telemetry.Config;

public class TelemetryOptions
{
    public string ServiceName { get; set; }
    public List<IApmExporter> ApmExporters { get; } = new();
    public List<ILogExporter> LogExporters { get; } = new();

    public TelemetryOptions AddApmExporter(IApmExporter exporter)
    {
        ApmExporters.Add(exporter);
        return this;
    }

    public TelemetryOptions AddLogExporter(ILogExporter exporter)
    {
        LogExporters.Add(exporter);
        return this;
    }
}