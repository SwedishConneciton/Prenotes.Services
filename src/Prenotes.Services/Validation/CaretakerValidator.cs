using FluentValidation;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        public AbstractValidator<Caretaker> CaretakerRules = new CaretakerRules();

        public AbstractValidator<int> CodeRules = new CodeRules();

        public CaretakerValidator(ICaretakerService srv): base(srv) {
        }

        public override Caretaker Confirm(Caretaker obj, int code) {
            CaretakerRules
                .Validate(obj)
                .MaybeExplode();
            CodeRules
                .Validate(code)
                .MaybeExplode();

            return base.Confirm(obj, code);    
        }
    }
}