using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Api.Endpoints;

internal static class GetDepartmentsEndpoint
{
    public static void MapGetDepartmentsEndpoint(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("get-departments", HandleAsync);
    }

    private static async Task<Results<Ok<IEnumerable<DepartmentDTO>>, NotFound>> HandleAsync(
        BogusDemoContext context,
        CancellationToken ct,
        int pageNumber = 1,
        int pageSize = 10)
    {
        var departments = await context.Departments
            .Include(d => d.Rooms)
            .OrderBy(d => d.Id)
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        var departmentDTOs = departments
            .Select(d => new DepartmentDTO(
                d.Id,
                d.Name,
                d.Rooms.Select(r => new RoomDTO(r.Id, r.RoomNumber))
            ));

        return departments.Count != 0
            ? TypedResults.Ok(departmentDTOs)
            : TypedResults.NotFound();
    }

    private record DepartmentDTO(int Id, string Name, IEnumerable<RoomDTO> Rooms);

    private record RoomDTO(int Id, string RoomNumber);
}