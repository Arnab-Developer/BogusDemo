namespace BogusDemo.Api.Endpoints;

internal static class DeleteRoomEndpoint
{
    public static void MapDeleteRoomEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapDelete("delete-room", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        DeleteRoomEndpointRequest request, IMediator mediator, CancellationToken ct)
    {
        var command = new DeleteRoomCommand(request.DepartmentId, request.RoomId);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }

    private record DeleteRoomEndpointRequest(int DepartmentId, int RoomId);
}