using Microsoft.Extensions.Logging;

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
        var response = await next(ct).ConfigureAwait(false);
        _logger.LogExecutionEnd();
        return response;
    }
}

internal static partial class LoggerExtensions
{
    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "Exution start.")]
    public static partial void LogExecutionStart(this ILogger logger);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Exution end.")]
    public static partial void LogExecutionEnd(this ILogger logger);
}