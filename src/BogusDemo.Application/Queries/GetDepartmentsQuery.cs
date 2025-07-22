using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Application.Queries;

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
            .ToListAsync(ct);

        return departments.ToDTOs();
    }
}

public record DepartmentDTO(int Id, string Name, IEnumerable<RoomDTO> Rooms);

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