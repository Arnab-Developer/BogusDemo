using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Application.Queries;

/// <summary>A query to get the departments data with its rooms.</summary>
/// <param name="PageNumber">The number of the page.</param>
/// <param name="PageSize">The size of the page.</param>
public record GetDepartmentsQuery(int PageNumber, int PageSize)
    : IRequest<IEnumerable<DepartmentDTO>>;

public class GetDepartmentsQueryHandler
    : IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDTO>>
{
    private readonly BogusDemoContext _context;

    public GetDepartmentsQueryHandler(BogusDemoContext context)
    {
        _context = context;
    }

    async Task<IEnumerable<DepartmentDTO>> IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDTO>>.Handle(
        GetDepartmentsQuery request, CancellationToken ct)
    {
        var departments = await _context.Departments
            .Include(d => d.Rooms)
            .OrderBy(d => d.Id)
            .AsNoTracking()
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(ct)
            .ConfigureAwait(false);

        return departments.ToDTOs();
    }
}

/// <summary>The department DTO.</summary>
/// <param name="Id">The id of the department.</param>
/// <param name="Name">The name of the department.</param>
/// <param name="Rooms">The rooms of the department.</param>
public record DepartmentDTO(int Id, string Name, IEnumerable<RoomDTO> Rooms);

/// <summary>The room DTO.</summary>
/// <param name="Id">The id of the room.</param>
/// <param name="RoomNumber">The number of the room.</param>
public record RoomDTO(int Id, string RoomNumber);

internal static class DepartmentsToDTOsConverterExtensions
{
    public static IEnumerable<DepartmentDTO> ToDTOs(this IEnumerable<Department> departments)
    {
        var departmentDTOs = departments
            .Select(d => new DepartmentDTO(
                d.Id,
                d.Name,
                d.Rooms.Select(r => new RoomDTO(r.Id, r.RoomNumber))
            ));

        return departmentDTOs;
    }
}