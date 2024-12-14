using FootballLeague.Application.Behaviors;
using FootballLeague.Application.Common.Mappings;
using FootballLeague.Domain.Matches;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddTransient<MatchScoreService>();

        return services;
    }
}
