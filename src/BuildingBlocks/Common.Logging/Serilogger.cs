using Microsoft.AspNetCore.Builder;
using Serilog;

namespace Common.Logging
{
    public static class Serilogger
    {
        public static void ConfigureSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog((ctx, lc) => lc
                .ReadFrom.Configuration(ctx.Configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console());
        }
    }
}
