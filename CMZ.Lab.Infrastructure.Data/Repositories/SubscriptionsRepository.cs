using CMZ.Lab.Domain.Entity;
using CMZ.Lab.Domain.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMZ.Lab.Infrastructure.Data
{
    /// <summary>
    /// Subscriptions repository
    /// </summary>
    /// <seealso cref="CMZ.Lab.Infrastructure.Interface.ISubscriptionsRepository" />
    public class SubscriptionsRepository: GenericRepository<Subscription> , ISubscriptionsRepository
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public SubscriptionsRepository(ApplicationDbContext context) : base(context) { }
        #endregion

        #region ISubscriptionsRepository
        /// <summary>
        /// Gets the subscriptions by user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Subscription>> GetSubscriptionsByUserId(int userId)
        {
            return await _dbContext.Subscriptions.Where(x => x.User.IdUser == userId).Include(x=>x.NotificationFrecuencie).Include(x=>x.EntityActivityType).AsTracking().ToListAsync();
        }
        #endregion
    }
}
