
using Serilog;

namespace GestionBibliotheque.Api.Extensions
{
    public static class SerilogExtensions
    {
        public static void AddSerilog(this IHostBuilder hostBuilder)
        {
            var logPath = Path.Combine(AppContext.BaseDirectory, "Logs");
            Directory.CreateDirectory(logPath);

            hostBuilder.UseSerilog((context, services, loggerConfiguration) =>
            {
                loggerConfiguration
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .WriteTo.File(
                        path: Path.Combine(logPath, "log-.txt"),
                        rollingInterval: RollingInterval.Day,
                        retainedFileCountLimit: 10,
                        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                    )
                    .ReadFrom.Configuration(context.Configuration); // Prendre les configurations de `appsettings.json`
            });
        }
    }
}
