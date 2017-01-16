using FluentValidation;
using FluentValidation.Results;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;
using System.Linq;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        private readonly AbstractValidator<Caretaker> caretakerRules;

        private readonly AbstractValidator<Handshake> handshakeRules;

        public CaretakerValidator(ICaretakerService srv, AbstractValidator<Caretaker> caretakerRules, AbstractValidator<Handshake> handshakeRules): base(srv) {
            this.caretakerRules = caretakerRules;
            this.handshakeRules = handshakeRules;
        }

        public override Caretaker Create(Caretaker obj, Handshake shake) {
            ValidationResult caretakerResults = caretakerRules.Validate(obj);

            if (!caretakerResults.IsValid) {
                throw new ValidationException(caretakerResults.Errors.First().ErrorMessage);
            }

            // Todo: Call validate on handshake rules

            // Todo: If not valid then throw exception

            return base.Create(obj, shake);    
        }
    }
}