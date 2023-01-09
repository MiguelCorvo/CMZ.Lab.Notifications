using CMZ.Lab.Application.Interface;
using CMZ.Lab.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CMZ.Lab.Services.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// The users service
        /// </summary>
        private readonly IUsersService _usersService;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUsersService userService)
        {
            _usersService = userService;
        }
        #endregion

        #region Get
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Users")]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersService.GetAllAsync();
        }
        #endregion
    }
}
