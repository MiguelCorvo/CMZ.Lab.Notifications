using CMZ.Lab.Application.DTO;
using CMZ.Lab.Application.Interface;
using CMZ.Lab.Domain.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMZ.Lab.Services.Controllers
{
    /// <summary>
    /// Subscription Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    
    [Authorize]
    [ApiController]
    [Route("[controller]")]   
    public class SubscriptionController : Controller
    {
        /// <summary>
        /// The subscriptions service
        /// </summary>
        private readonly ISubscriptionsService _subscriptionsService;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionController" /> class.
        /// </summary>
        /// <param name="subscriptionsService">The subscriptions service.</param>
        public SubscriptionController(ISubscriptionsService subscriptionsService)
        {
            _subscriptionsService = subscriptionsService;
        }
        #endregion

        #region Get
        /// <summary>
        /// Obtiene las suscripiciones por el identificador del usuario.
        /// </summary>
        /// <param name="userId">Identificador Usuario</param>
        /// <response code="200">Suscripciones del usuario</response>
        /// <response code="404">Usuario sin suscripciones</response>
        /// <response code="400">Excepción Interna</response>
        /// <returns></returns>
        [HttpGet("SubsrcriptionsByUser")]
        public async Task<ActionResult<Subscription>> GetSubscriptionsByUserId(int userId)
        {
            try
            {
                var suscriptions = await _subscriptionsService.GetSubscriptionsByUserId(userId);
                if (!suscriptions.Any())
                {
                    return NotFound();
                }

                return Ok(suscriptions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene las suscripiciones con DTO por el identificador del usuario.
        /// </summary>
        /// <param name="userId">Identificador Usuario</param>
        /// <response code="200">Suscripciones del usuario</response>
        /// <response code="404">Usuario sin suscripciones</response>
        /// <response code="400">Excepción Interna</response>
        /// <returns></returns>
        [HttpGet("SubsrcriptionsDTOByUser")]
        public async Task<ActionResult<SubscriptionDTO>> GetSubscriptionsDTOByUserId(int userId)
        {
            try
            {
                var suscriptions = await _subscriptionsService.GetSubscriptionsDTOByUserId(userId);
                if (!suscriptions.Any())
                {
                    return NotFound();
                }

                return Ok(suscriptions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Post
        /// <summary>
        /// Crea las subscripciones.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpPost("CreateSubscriptions")]
        public async Task<ActionResult> PostSubscriptiosDTO(CreateSubscriptionDTO[] subscriptions, int userId)
        {
            try
            {
                bool result = await _subscriptionsService.CreateSubscriptionsAsync(subscriptions, userId);
                if (!result)
                    return NotFound(result);
                else
                    return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}
