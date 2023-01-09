using CMZ.Lab.Application.Interface;
using CMZ.Lab.Domain.Entity;
using CMZ.Lab.Domain.Interface.UnitOrWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMZ.Lab.Application.Main
{
    /// <summary>
    /// Service for subscriptions
    /// </summary>
    /// <seealso cref="CMZ.Lab.Application.Interface.ISubscriptionsService" />
    public class UsersService : IUsersService
    {
        #region Private Field
        /// <summary>
        /// The unit of work
        /// </summary>
        public IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public UsersService(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Users Service
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<User>> GetAllAsync()
        {
            return _unitOfWork.UsersRepository.GetAllAsync();
        }        
        #endregion
    }
}
