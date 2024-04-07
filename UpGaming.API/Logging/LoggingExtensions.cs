using Serilog;

namespace UpGaming.API.Logging
{
    public static class LoggingExtensions
    {
        public static void AddLogging(this WebApplicationBuilder builder)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .Enrich.WithProperty("Environment", Environment.UserName).CreateLogger();
            builder.Host.UseSerilog();
        }
    }
}
