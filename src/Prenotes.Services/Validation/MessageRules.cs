

using FluentValidation;

namespace Prenotes.Services.Validation {

    public class MessageRules: AbstractValidator<string> {
        
        public MessageRules() {
            // TODO: Need a rule that checks that the message 
            //       that will become a Notificaiton isn't empty
            //       and not greater than 144.  The selector passed to 
            //       the "RuleFor" method will be like in CodeRules.cs 
            //       (i.e. just "x => x").  This is because the type
            //       assigned in the class definition 
            //       "class MessageRules: AbstractValidator<string>" above
            //       is a string.  So the variable "x" is a string and we 
            //       want to return it's value.  Tips:  Chain together
            //       the "NotEmpty" and "LessThanOrEqual" methods where 
            //       only arugment with "LessThanOrEqual" will be 144.
        }
    }
}