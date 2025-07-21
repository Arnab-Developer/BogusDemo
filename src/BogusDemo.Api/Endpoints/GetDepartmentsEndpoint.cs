using BogusDemo.Core;
using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Api.Endpoints;

internal static class GetDepartmentsEndpoint
{
    public static void MapGetDepartmentsEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("get-departments", HandleAsync);
    }

    private static async Task<Results<Ok<IEnumerable<Department>>, NotFound>> HandleAsync(
        int pageNumber, int pageSize, BogusDemoContext context, CancellationToken ct)
    {
        var departments = await context.Departments
            .Include(d => d.Rooms)
            .OrderBy(d => d.Id)
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return departments.Count != 0
            ? TypedResults.Ok(departments.AsEnumerable())
            : TypedResults.NotFound();
    }
}