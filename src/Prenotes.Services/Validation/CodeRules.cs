
using FluentValidation;

namespace Prenotes.Services.Validation {
    public class CodeRules : AbstractValidator<int> {
        public CodeRules() {
            RuleFor(x => x)
                .NotEmpty();
        }
    }
}