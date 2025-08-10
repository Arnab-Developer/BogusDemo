namespace BogusDemo.Api.Endpoints;

internal static class DeleteDepartmentEndpoint
{
    public static void MapDeleteDepartmentEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapDelete("delete-department", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        DeleteDepartmentEndpointRequest request, IMediator mediator, CancellationToken ct)
    {
        var command = new DeleteDepartmentCommand(request.DepartmentId);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }

    private record DeleteDepartmentEndpointRequest(int DepartmentId);
}