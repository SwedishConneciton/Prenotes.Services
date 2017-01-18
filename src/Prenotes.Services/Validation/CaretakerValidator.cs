using FluentValidation;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        public AbstractValidator<Caretaker> CaretakerRules = new CaretakerRules();

        public AbstractValidator<string> CodeRules = new CodeRules();

        public CaretakerValidator(ICaretakerService srv): base(srv) {
        }

        
        public override Caretaker Confirm(Caretaker obj, string code) {
            CaretakerRules
                .Validate(obj)
                .MaybeExplode();
           
                CodeRules
                .Validate(code)
                .MaybeExplode();

            return base.Confirm(obj, code);    
        }

       
        public override Caretaker Edit(Caretaker obj) {
            // BONUS TODO: Add validation of the passed "obj" just like 
            //             in the "Confirm" method above then add a 
            //             test case for it.

            return base.Edit(obj);
        }
    }
}