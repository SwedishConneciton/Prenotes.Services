
using FluentValidation;

namespace Prenotes.Services.Validation {
    public class CodeRules : AbstractValidator<string> {
        public CodeRules() {
            // TODO: The code is a string which ought to be at least 6 characters long so 
            // a good solution here might be to the Length built-in validator.
            // See https://github.com/JeremySkinner/FluentValidation/wiki/c.-Built-In-Validators
            RuleFor(x => x)
                .NotEmpty()
                .Length(6, int.MaxValue);
        }
    }
}