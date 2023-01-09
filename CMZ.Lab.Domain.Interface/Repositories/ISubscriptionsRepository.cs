using CMZ.Lab.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CMZ.Lab.Domain.Interface.Repositories
{
    /// <summary>
    /// Interface for Subscription Repository
    /// </summary>
    public interface ISubscriptionsRepository : IGenericRepository<Subscription>
    {
        /// <summary>
        /// Gets the subscriptions by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserId(int userId);
    }
}
