using BogusDemo.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BogusDemo.Api.Endpoints;

internal static class ChangeDepartmentNameEndpoint
{
    public static void MapChangeDepartmentNameEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapPost("change-department-name", HandleAsync);
    }

    private static async Task<Results<Ok, NotFound>> HandleAsync(
        int id, string name, IMediator mediator, CancellationToken ct)
    {
        var command = new ChangeDepartmentNameCommand(id, name);
        var isSuccess = await mediator.Send(command, ct);

        return isSuccess ? TypedResults.Ok() : TypedResults.NotFound();
    }
}