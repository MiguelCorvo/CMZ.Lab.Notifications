using CMZ.Lab.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMZ.Lab.Application.Interface
{
    /// <summary>
    /// Interface for Subscriptions users
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<User>> GetAllAsync();
    }
}
