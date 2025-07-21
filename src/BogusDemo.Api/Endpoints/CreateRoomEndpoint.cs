namespace BogusDemo.Api.Endpoints;

internal static class CreateRoomEndpoint
{
    public static void MapCreateRoomEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPut("create-room", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        int id, string roomNumber, IMediator mediator, CancellationToken ct)
    {
        var command = new CreateRoomCommand(id, roomNumber);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }
}