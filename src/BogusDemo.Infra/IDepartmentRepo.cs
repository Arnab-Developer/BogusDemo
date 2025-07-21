using BogusDemo.Core;

namespace BogusDemo.Infra;

/// <summary>Repo of the department.</summary>
public interface IDepartmentRepo
{
    /// <summary>Add new department.</summary>
    /// <param name="department">The new department.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public Task AddAsync(Department department, CancellationToken ct);

    /// <summary>Delete the department.</summary>
    /// <param name="department">The existing department.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public Task DeleteAsync(Department department, CancellationToken ct);

    /// <summary>Gets a department by id.</summary>
    /// <param name="id">The id of the existing department.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task containing a department object.</returns>
    public Task<Department> GetAsync(int id, CancellationToken ct);

    /// <summary>Save the changes in the datastore.</summary>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public Task SaveChangesAsync(CancellationToken ct);
}