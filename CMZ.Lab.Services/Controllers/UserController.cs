using CMZ.Lab.Application.DTO;
using CMZ.Lab.Application.Interface;
using CMZ.Lab.Domain.Entity;
using CMZ.Lab.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CMZ.Lab.Services.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// The users service
        /// </summary>
        private readonly IUsersService _usersService;

        /// <summary>
        /// The application settings
        /// </summary>
        private readonly AppSettings _appSettings;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionController" /> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="appSettings">The application settings.</param>
        public UserController(IUsersService userService, IOptions<AppSettings> appSettings)
        {
            _usersService = userService;
            _appSettings = appSettings.Value;
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

        /// <summary>
        /// Autenticar usuario
        /// </summary>
        /// <param name="userDto">Usuario</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] UserDto userDto)
        {
            // TO-DO: Logic for control user in database.
            userDto.Token = BuildToken(userDto);
            return Ok(userDto);
        }
        #endregion

        #region Private Memebers
        /// <summary>
        /// Builds the token.
        /// </summary>
        /// <param name="usersDto">The users dto.</param>
        /// <returns></returns>
        private string BuildToken(UserDto usersDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDto.User.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        #endregion
    }
}
