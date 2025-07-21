namespace BogusDemo.Api.Endpoints;

internal static class CreateDepartmentEndpoint
{
    public static void MapCreateDepartmentEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPut("create-department", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        string name, IMediator mediator, CancellationToken ct)
    {
        var command = new CreateDepartmentCommand(name);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }
}