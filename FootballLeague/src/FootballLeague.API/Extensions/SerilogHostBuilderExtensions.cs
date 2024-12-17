using Serilog;

namespace FootballLeague.API.Extensions;

public static class SerilogHostBuilderExtensions
{
    public static IHostBuilder UseCustomSerilog(this IHostBuilder builder)
    {
        builder.UseSerilog(
            (context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
        );

        return builder;
    }
}
