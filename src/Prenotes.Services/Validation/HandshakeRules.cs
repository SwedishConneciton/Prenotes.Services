
using FluentValidation;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {
    public class HandshakeRules : AbstractValidator<Handshake> {
        public HandshakeRules() {
            RuleFor(x => x.email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}