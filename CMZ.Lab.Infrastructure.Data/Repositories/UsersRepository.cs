using CMZ.Lab.Domain.Entity;
using CMZ.Lab.Domain.Interface.Repositories;

namespace CMZ.Lab.Infrastructure.Data
{
    /// <summary>
    /// Users Repository
    /// </summary>
    /// <seealso cref="CMZ.Lab.Infrastructure.Interface.IUsersRepository" />
    public class UsersRepository: GenericRepository<User>, IUsersRepository
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersRepository"/> class.
        /// </summary>
        /// <param name="context"></param>
        public UsersRepository(ApplicationDbContext context) : base(context) { }
        #endregion
    }
}
