using CMZ.Lab.Application.DTO;
using FluentValidation;

namespace CMZ.Lab.Application.Main.Validations
{
    /// <summary>
    /// Validator for subscription DTO
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CMZ.Lab.Application.DTO.CreateSubscriptionDTO&gt;" />
    public class SubscriptionsDTOValidator : AbstractValidator<CreateSubscriptionsDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionDTOValidator"/> class.
        /// </summary>
        public SubscriptionsDTOValidator()
        {
            RuleForEach(x => x.CreateSubscription).SetValidator(new SubscriptionDTOValidator());
        }
    }
}
