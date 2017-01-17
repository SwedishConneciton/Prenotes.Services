
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {
    public class CaretakerRules : AbstractValidator<Caretaker> {

        /// <summary>
        /// 
        /// </summary>
        public CaretakerRules() {
            // TODO: The validation library we use https://github.com/JeremySkinner/FluentValidation/wiki 
            // can even help us make sure the other properties are correct
            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();

            // TODO: Do we need to have checks on the "created" property (Hint: probably not)

            // TODO: What about the "name" property?  (Hint: probably not)
        }
    }
}