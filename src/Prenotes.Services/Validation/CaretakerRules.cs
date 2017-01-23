
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

           
        
             RuleFor(x => x.created)
              .GreaterThanOrEqualTo(0);
                
        }
    }
}