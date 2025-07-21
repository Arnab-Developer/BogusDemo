using BogusDemo.Infra;
using MediatR;

namespace BogusDemo.Application.Behaviors;

public class TransactionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly BogusDemoContext _context;

    public TransactionBehavior(BogusDemoContext context)
    {
        _context = context;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(ct).ConfigureAwait(false);
        var response = await next(ct).ConfigureAwait(false);
        await transaction.CommitAsync(ct).ConfigureAwait(false);
        return response;
    }
}