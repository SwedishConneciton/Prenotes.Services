
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {
    public class CaretakerRules : AbstractValidator<Caretaker> {

        /// <summary>
        /// 
        /// </summary>
        public CaretakerRules() {
            // INFO: "RuleFor" comes from AbstractValidator and wants a function as 
            //       the first parameter.  That function just returns a value that 
            //       could come from a property of the type set when extending AbstractValidator
            //       (i.e. Caretaker in AbstractValidator<Caretaker>).
            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();

            // TODO: Another rule for making sure that the "created" property
            //       is not negative.  See https://github.com/JeremySkinner/FluentValidation/wiki/c.-Built-In-Validators 
            //       and look at the "GreaterThanOrEqual" validator.  That default 
            //       validator probably only takes one parameter

            /* RuleFor(x => x.created) */
        }
    }
}