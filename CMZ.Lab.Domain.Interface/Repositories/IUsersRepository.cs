using CMZ.Lab.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMZ.Lab.Domain.Interface.Repositories
{
    /// <summary>
    /// Interface for User Repository
    /// </summary>
    /// <seealso cref="CMZ.Lab.Domain.Interface.IGenericRepository&lt;CMZ.Lab.Domain.Entity.User&gt;" />
    public interface IUsersRepository : IGenericRepository<User>
    {
    }
}
