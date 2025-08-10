namespace BogusDemo.Api.Endpoints;

internal static class ChangeDepartmentNameEndpoint
{
    public static void MapChangeDepartmentNameEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("change-department-name", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        ChangeDepartmentNameEndpointRequest request, IMediator mediator, CancellationToken ct)
    {
        var command = new ChangeDepartmentNameCommand(request.Id, request.Name);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }

    private record ChangeDepartmentNameEndpointRequest(int Id, string Name);
}