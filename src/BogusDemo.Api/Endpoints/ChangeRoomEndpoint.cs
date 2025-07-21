namespace BogusDemo.Api.Endpoints;

internal static class ChangeRoomEndpoint
{
    public static void MapChangeRoomEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("change-room", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        int departmentId,
        int roomId,
        string roomNumber,
        IMediator mediator,
        CancellationToken ct)
    {
        var command = new ChangeRoomCommand(departmentId, roomId, roomNumber);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }
}