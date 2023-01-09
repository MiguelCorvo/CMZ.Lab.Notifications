using CMZ.Lab.Application.DTO;
using CMZ.Lab.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMZ.Lab.Application.Interface
{
    /// <summary>
    /// Interface for Subscriptions Service
    /// </summary>
    public interface ISubscriptionsService
    {
        /// <summary>
        /// Gets the subscriptions by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<Subscription>> GetSubscriptionsByUserId(int id);

        /// <summary>
        /// Gets the subscriptions DTO by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<IEnumerable<SubscriptionDTO>> GetSubscriptionsDTOByUserId(int id);

        /// <summary>
        /// Creates the subscriptions asynchronous.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        /// <returns></returns>
        Task<bool> CreateSubscriptionsAsync(IEnumerable<CreateSubscriptionDTO> subscriptions, int userId);        
    }
}
