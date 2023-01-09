using CMZ.Lab.Domain.Entity;
using CMZ.Lab.Domain.Interface.Repositories;
using CMZ.Lab.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMZ.Lab.Infrastructure.Repository
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
        public async Task<Subscription> GetSubscriptionsByUserId(int userId)
        {
            return await  _dbContext.Subscriptions.FirstOrDefaultAsync(x=>x.Id == userId);
        }
        #endregion
    }
}
