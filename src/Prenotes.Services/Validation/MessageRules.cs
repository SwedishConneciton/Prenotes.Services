

using FluentValidation;

namespace Prenotes.Services.Validation {

    public class MessageRules: AbstractValidator<string> {
        
        public MessageRules() {
            RuleFor(x => x)
                .NotEmpty() 
                .Length(1,144); 
        }
    }
}