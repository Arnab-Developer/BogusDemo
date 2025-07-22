namespace BogusDemo.Infra;

/// <summary>The genearic repo.</summary>
/// <typeparam name="T">Generic type parameter should be 
/// <see cref="IAggregateRoot"/> type.</typeparam>
public interface IRepo<T> where T : IAggregateRoot
{
    /// <summary>Add new data.</summary>
    /// <param name="data">The new data.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public Task AddAsync(T data, CancellationToken ct);

    /// <summary>Delete the data.</summary>
    /// <param name="data">The existing data.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public Task DeleteAsync(T data, CancellationToken ct);

    /// <summary>Gets a data by id.</summary>
    /// <param name="id">The id of the existing data.</param>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task containing a data object.</returns>
    public Task<T> GetAsync(int id, CancellationToken ct);

    /// <summary>Save the changes in the datastore.</summary>
    /// <param name="ct">The cancellation token to cancel the async work.</param>
    /// <returns>A task.</returns>
    public Task SaveChangesAsync(CancellationToken ct);
}