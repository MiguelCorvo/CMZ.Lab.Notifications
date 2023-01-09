using CMZ.Lab.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace CMZ.Lab.Infrastructure.Data
{
    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="CMZ.Lab.Domain.Interface.IGenericRepository&lt;T&gt;" />
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Private Fields
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// The entitiy set
        /// </summary>
        private readonly DbSet<T> _entitiySet;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }
        #endregion

        #region IGenericRepository
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _entitiySet.AsEnumerable();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entitiySet.ToListAsync();
        }

        /// <summary>
        /// Gets the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            return await _entitiySet.FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.UpdateRange(entities);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
        #endregion
    }
}
