using BogusDemo.Application.Queries;

namespace BogusDemo.Api.Endpoints;

internal static class GetDepartmentsEndpoint
{
    public static void MapGetDepartmentsEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("get-departments", HandleAsync);
    }

    private static async Task<Results<Ok<IEnumerable<DepartmentDTO>>, NotFound>> HandleAsync(
        IMediator mediator,
        CancellationToken ct,
        int pageNumber = 1,
        int pageSize = 10)
    {
        var query = new GetDepartmentsQuery(pageNumber, pageSize);
        var departmentDTOs = await mediator.Send(query);

        return departmentDTOs.Any()
            ? TypedResults.Ok(departmentDTOs)
            : TypedResults.NotFound();
    }
}