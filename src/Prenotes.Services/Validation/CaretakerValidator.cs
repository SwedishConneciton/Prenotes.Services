using FluentValidation;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        public AbstractValidator<Caretaker> CaretakerRules = new CaretakerRules();

        public AbstractValidator<string> CodeRules = new CodeRules();

        public CaretakerValidator(ICaretakerService srv): base(srv) {
        }

        // TODO: Uncomment the CodeRules to check the code parameter
        // TODO: Read https://github.com/JeremySkinner/FluentValidation/wiki to understand rules
        public override Caretaker Confirm(Caretaker obj, string code) {
            CaretakerRules
                .Validate(obj)
                .MaybeExplode();
            /**
            CodeRules
                .Validate(code)
                .MaybeExplode();
            */

            return base.Confirm(obj, code);    
        }

        // TODO: Implement Validation (i.e. just like Confirm)
        public override Caretaker Edit(Caretaker obj) {
            return base.Edit(obj);
        }
    }
}