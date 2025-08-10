namespace BogusDemo.Api.Endpoints;

internal static class ChangeRoomEndpoint
{
    public static void MapChangeRoomEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("change-room", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        ChangeRoomEndpointRequest request, IMediator mediator, CancellationToken ct)
    {
        var command = new ChangeRoomCommand(request.DepartmentId, request.RoomId, request.RoomNumber);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }

    private record ChangeRoomEndpointRequest(int DepartmentId, int RoomId, string RoomNumber);
}