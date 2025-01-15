using System.Linq.Expressions;

namespace NDC_Core_DataBridge.Interfaces
{
    /// <summary>
    /// Generic Repository Interface for CRUD Operations.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieve a single entity that matches the given predicate.
        /// </summary>
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Retrieve all entities, optionally filtered by a predicate.
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null);

        /// <summary>
        /// Add a single entity to the database.
        /// </summary>
        Task AddAsync(T entity);

        /// <summary>
        /// Add multiple entities to the database.
        /// </summary>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Update a single entity in the database.
        /// </summary>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Delete a single entity from the database.
        /// </summary>
        Task DeleteAsync(T entity);

        /// <summary>
        /// Delete multiple entities from the database.
        /// </summary>
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
