
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {
    public class HandshakeRules : AbstractValidator<Handshake> {
        public HandshakeRules() {
            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();

            // Todo: What other rules are need?
            // Look at https://github.com/JeremySkinner/FluentValidation/wiki
            // Remember that Handshake has to have a code and that 
            // code ought to be at least 6 numbers (no letters needed)
        }
    }
}