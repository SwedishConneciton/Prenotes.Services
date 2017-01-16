
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {
    public class CaretakerRules : AbstractValidator<Caretaker> {
        public CaretakerRules() {
            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}