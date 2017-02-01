
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class ChildRules : AbstractValidator<Child> {
        
        public ChildRules() {
           RuleFor(x => x.name)
           .NotEmpty();
        }
    }
}