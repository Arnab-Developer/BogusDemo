using BogusDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BogusDemo.Api.Endpoints;

internal static class DeleteDepartmentEndpoint
{
    public static void MapDeleteDepartmentEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapDelete("delete-department", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        int departmentId, IMediator mediator, CancellationToken ct)
    {
        var command = new DeleteDepartmentCommand(departmentId);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }
}