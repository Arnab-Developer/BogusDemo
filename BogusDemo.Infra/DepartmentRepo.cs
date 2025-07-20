using BogusDemo.Core;
using Microsoft.EntityFrameworkCore;

namespace BogusDemo.Infra;

public class DepartmentRepo : IDepartmentRepo
{
    private readonly BogusDemoContext _context;

    public DepartmentRepo(BogusDemoContext context)
    {
        _context = context;
    }

    async Task IDepartmentRepo.AddAsync(Department department, CancellationToken ct)
    {
        await _context.Departments.AddAsync(department, ct).ConfigureAwait(false);
    }

    async Task IDepartmentRepo.UpdateAsync(int id, Department department, CancellationToken ct)
    {
        await Task.CompletedTask;
    }

    async Task IDepartmentRepo.DeleteAsync(int id, CancellationToken ct)
    {
        var department = await _context.Departments.FirstAsync(d => d.Id == id, ct)
            .ConfigureAwait(false);

        _context.Departments.Remove(department);
    }

    async public Task<Department> Get(int id, CancellationToken ct)
    {
        var department = await _context.Departments.FirstAsync(d => d.Id == id, ct)
            .ConfigureAwait(false);

        return department;
    }

    async Task IDepartmentRepo.SaveChangesAsunc(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}