using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BogusDemo.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        _logger.LogExecutionStart();
        var stopWatch = Stopwatch.StartNew();

        var response = await next(ct).ConfigureAwait(false);

        stopWatch.Stop();
        _logger.LogExecutionEnd(stopWatch.ElapsedMilliseconds);

        return response;
    }
}

internal static partial class LoggerExtensions
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Execution start.")]
    public static partial void LogExecutionStart(this ILogger logger);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, 
        Message = "Execution end. Took {elapsedMilliseconds}")]
    public static partial void LogExecutionEnd(this ILogger logger, long elapsedMilliseconds);
}