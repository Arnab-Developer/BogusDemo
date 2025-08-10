namespace BogusDemo.Api.Endpoints;

internal static class CreateRoomEndpoint
{
    public static void MapCreateRoomEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPut("create-room", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        CreateRoomEndpointRequest request, IMediator mediator, CancellationToken ct)
    {
        var command = new CreateRoomCommand(request.Id, request.RoomNumber);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }

    private record CreateRoomEndpointRequest(int Id, string RoomNumber);
}