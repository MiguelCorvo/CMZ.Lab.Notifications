using CMZ.Lab.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMZ.Lab.Application.Main.Validations
{
    /// <summary>
    /// Validator for subscription DTO
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;CMZ.Lab.Application.DTO.CreateSubscriptionDTO&gt;" />
    public class SubscriptionDTOValidator : AbstractValidator<CreateSubscriptionDTO>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionDTOValidator"/> class.
        /// </summary>
        public SubscriptionDTOValidator()
        {
            RuleFor(x => x.IdEntity).GreaterThan((short)0).WithMessage("El Campo IdEntity no puede ser 0.");
        }
    }
}
