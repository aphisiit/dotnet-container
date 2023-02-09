using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace LogConfigure;
public class LogConfigure
{
    public LogConfigure()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console(outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}",
            theme: AnsiConsoleTheme.Code)
            .CreateLogger();
    }
}
