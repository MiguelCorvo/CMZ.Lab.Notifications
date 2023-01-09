using CMZ.Lab.Domain.Interface.Repositories;
using CMZ.Lab.Domain.Interface.UnitOrWork;
using System;
using System.Threading.Tasks;

namespace CMZ.Lab.Infrastructure.Data
{
    /// <summary>
    /// Unit of Work
    /// </summary>
    /// <seealso cref="CMZ.Lab.Domain.Interface.UnitOrWork.IUnitOfWork" />
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Fields
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// The user respository
        /// </summary>
        private IUsersRepository _userRespository;

        /// <summary>
        /// The subsriptions repository
        /// </summary>
        private ISubscriptionsRepository _subscriptionsRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context= context;
        }
        #endregion

        #region IUnitOfWork
        /// <summary>
        /// Gets the users repository.
        /// </summary>
        /// <value>
        /// The users repository.
        /// </value>
        public IUsersRepository UsersRepository
        {
            get { return _userRespository = _userRespository ?? new UsersRepository(_context); }
        }

        /// <summary>
        /// Gets the subscriptions repository.
        /// </summary>
        /// <value>
        /// The subscriptions repository.
        /// </value>
        public ISubscriptionsRepository SubscriptionsRepository
        {
            get { return _subscriptionsRepository = _subscriptionsRepository ?? new SubscriptionsRepository(_context); }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        /// <returns></returns>
        public void Rollback()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Rollbacks the asynchronous.
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();            
        }
        #endregion
    }
}
