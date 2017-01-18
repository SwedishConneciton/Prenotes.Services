
using FluentValidation;

namespace Prenotes.Services.Validation {
    public class CodeRules : AbstractValidator<string> {
        public CodeRules() {
            RuleFor(x => x)
                .NotEmpty()
                .Length(6, int.MaxValue);
        }
    }
}