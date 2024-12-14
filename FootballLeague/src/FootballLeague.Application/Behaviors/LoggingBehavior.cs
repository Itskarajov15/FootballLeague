using MediatR;
using Microsoft.Extensions.Logging;

namespace FootballLeague.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
{
    private const string Query = "Query";
    private const string Command = "Command";
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation($"Executing {GetCommandOrQueryName(name)} {name}");

            var result = await next();

            _logger.LogInformation($"{GetCommandOrQueryName(name)} {name} processed successfully");

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred while processing {GetCommandOrQueryName(name)} {name} : {ex}");

            throw;
        }
    }

    private string GetCommandOrQueryName(string name)
        => name.EndsWith(Query) ? Query : Command;
}
