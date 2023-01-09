using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace CMZ.Lab.Domain.Interface
{
    /// <summary>
    /// Interface Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        Task<T> Get(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        void UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);
    }
}
