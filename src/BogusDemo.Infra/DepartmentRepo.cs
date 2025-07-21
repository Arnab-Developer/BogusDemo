using BogusDemo.Core;
using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Infra;

/// <summary>Repo of the department.</summary>
public class DepartmentRepo : IDepartmentRepo
{
    private readonly BogusDemoContext _context;

    /// <summary>Create a new object of department repo.</summary>
    /// <param name="context">The department db context.</param>
    public DepartmentRepo(BogusDemoContext context)
    {
        _context = context;
    }

    async Task IDepartmentRepo.AddAsync(Department department, CancellationToken ct)
    {
        await _context.Departments.AddAsync(department, ct).ConfigureAwait(false);
    }

    async Task IDepartmentRepo.DeleteAsync(Department department, CancellationToken ct)
    {
        _context.Departments.Remove(department);
        await Task.CompletedTask;
    }

    async public Task<Department> GetAsync(int id, CancellationToken ct)
    {
        var department = await _context.Departments
            .Include(d => d.Rooms)
            .FirstAsync(d => d.Id == id, ct)
            .ConfigureAwait(false);

        return department;
    }

    async Task IDepartmentRepo.SaveChangesAsync(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}