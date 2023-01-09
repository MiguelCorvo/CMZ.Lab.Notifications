using AutoMapper;
using CMZ.Lab.Application.DTO;
using CMZ.Lab.Application.Interface;
using CMZ.Lab.Domain.Entity;
using CMZ.Lab.Domain.Interface.UnitOrWork;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMZ.Lab.Application.Main
{
    /// <summary>
    /// Service for subscriptions
    /// </summary>
    /// <seealso cref="CMZ.Lab.Application.Interface.ISubscriptionsService" />
    public class SubscriptionsService : ISubscriptionsService
    {
        #region Private Field
        /// <summary>
        /// The unit of work
        /// </summary>
        public IUnitOfWork _unitOfWork;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// The validator
        /// </summary>
        private readonly IValidator<CreateSubscriptionsDTO> _validator;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionsService" /> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="validator">The validator.</param>
        public SubscriptionsService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateSubscriptionsDTO> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }
        #endregion

        #region Subscriptions Service
        /// <summary>
        /// Gets the subscriptions by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Subscription>> GetSubscriptionsByUserId(int id)
        {
            return await _unitOfWork.SubscriptionsRepository.GetSubscriptionsByUserId(id);
        }

        /// <summary>
        /// Gets the subscriptions DTO by user identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<SubscriptionDTO>> GetSubscriptionsDTOByUserId(int id)
        {
            var subscriptions = await _unitOfWork.SubscriptionsRepository.GetSubscriptionsByUserId(id);
            var subscriptionsDTO = _mapper.Map<IEnumerable<SubscriptionDTO>>(subscriptions);
            return subscriptionsDTO;
        }

        /// <summary>
        /// Creates the subscriptions asynchronous.
        /// </summary>
        /// <param name="subscriptions">The subscriptions.</param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> CreateSubscriptionsAsync(IEnumerable<CreateSubscriptionDTO> subscriptions, int userId)
        {
            if (!subscriptions.Any())
                return false;
            else
            {
                // Validations
                var validatioResult = await _validator.ValidateAsync(new CreateSubscriptionsDTO() { CreateSubscription = subscriptions.ToList() });
                if (!validatioResult.IsValid)
                {
                    string errors = string.Empty;
                    foreach (var failure in validatioResult.Errors)
                    {
                        errors = errors + failure.ErrorMessage;                         
                    }
                    throw new Exception(errors);
                }

                User user = await _unitOfWork.UsersRepository.Get(x => x.IdUser == userId);
                if (user == null) return false;

                // Updates
                IEnumerable<CreateSubscriptionDTO> subscriptionsDTOToUpdate = subscriptions.Where(x => x.IdSubscription > 0);
                if (subscriptionsDTOToUpdate.Any())
                {
                    var subscriptionsUser = await _unitOfWork.SubscriptionsRepository.GetSubscriptionsByUserId(userId);
                    foreach (CreateSubscriptionDTO item in subscriptionsDTOToUpdate)
                    {
                        Subscription match = subscriptionsUser.Where(x => x.IdSubscription == item.IdSubscription).FirstOrDefault();
                        if (match != null)
                        {
                            match = _mapper.Map(item, match);
                            _unitOfWork.SubscriptionsRepository.Update(match);
                        }
                    }
                }

                //Inserts
                IEnumerable<CreateSubscriptionDTO> subscriptionsDTOToInsert = subscriptions.Where(x => x.IdSubscription == 0);
                if (subscriptionsDTOToInsert.Any())
                {
                    var subscriptionsToInsert = _mapper.Map<IEnumerable<CreateSubscriptionDTO>, IEnumerable<Subscription>>(subscriptionsDTOToInsert);
                    foreach (Subscription item in subscriptionsToInsert)
                    {
                        item.User = user;
                        item.DateCreation = DateTime.Now;
                    }
                    await _unitOfWork.SubscriptionsRepository.AddRangeAsync(subscriptionsToInsert);
                }

                // _unitOfWork.Commit();  Don't update Database.
                return true;
            }
        }
        #endregion
    }
}
