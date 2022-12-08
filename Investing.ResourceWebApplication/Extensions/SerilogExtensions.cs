using Serilog;

namespace Investing.ResourceWebApplication.Extensions
{
    public static class SerilogExtensions
    {
        public static void UseSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog((context, configuration) => configuration
                .WriteTo.Console().ReadFrom.Configuration(context.Configuration)
                .WriteTo.Seq(Environment.GetEnvironmentVariable("ASPNETCORE_SEQ_SERVER")));
        }

        public static void UseSerilogLogging(this IApplicationBuilder builder)
        {
            builder.UseSerilogRequestLogging();
        }
    }
}
