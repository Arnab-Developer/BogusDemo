using BogusDemo.Core.DepartmentAggregateRoot;

namespace BogusDemo.Infra;

/// <summary>The department repo.</summary>
public class DepartmentRepo : IDepartmentRepo
{
    private readonly BogusDemoContext _context;

    /// <summary>Create a new object of department repo.</summary>
    /// <param name="context">The department db context.</param>
    public DepartmentRepo(BogusDemoContext context)
    {
        _context = context;
    }

    /// <summary>Add new department.</summary>
    /// <param name="department">The new department.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public async Task AddAsync(Department department, CancellationToken ct)
    {
        await _context.Departments.AddAsync(department, ct).ConfigureAwait(false);
    }

    /// <summary>Delete the department.</summary>
    /// <param name="department">The existing department.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public async Task DeleteAsync(Department department, CancellationToken ct)
    {
        _context.Departments.Remove(department);
        await Task.CompletedTask;
    }

    /// <summary>Gets a department by id.</summary>
    /// <param name="id">The id of the existing department.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task containing a department object.</returns>
    public async Task<Department> GetAsync(int id, CancellationToken ct)
    {
        var department = await _context.Departments
            .Include(d => d.Rooms)
            .FirstAsync(d => d.Id == id, ct)
            .ConfigureAwait(false);

        return department;
    }

    /// <summary>Save the changes in the datastore.</summary>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public async Task SaveChangesAsync(CancellationToken ct)
    {
        await _context.SaveChangesAsync(ct).ConfigureAwait(false);
    }
}