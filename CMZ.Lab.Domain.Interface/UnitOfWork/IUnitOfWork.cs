using CMZ.Lab.Domain.Interface.Repositories;
using System.Threading.Tasks;

namespace CMZ.Lab.Domain.Interface.UnitOrWork
{
    /// <summary>
    /// Interface Unit of Work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the users repository.
        /// </summary>
        /// <value>
        /// The users repository.
        /// </value>
        IUsersRepository UsersRepository { get; }

        /// <summary>
        /// Gets the subscriptions repository.
        /// </summary>
        /// <value>
        /// The subscriptions repository.
        /// </value>
        ISubscriptionsRepository SubscriptionsRepository { get; }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks this instance.
        /// </summary>
        void Rollback();

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task CommitAsync();

        /// <summary>
        /// Rollbacks the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task RollbackAsync();
    }
}
