using FluentValidation;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        public AbstractValidator<Caretaker> CaretakerRules = new CaretakerRules();

        public AbstractValidator<string> CodeRules = new CodeRules();

        public CaretakerValidator(ICaretakerService srv): base(srv) {
        }

        
        public override Caretaker Confirm(string email, string code) {           
            CodeRules
                .Validate(code)
                .MaybeExplode();

            return base.Confirm(email, code);    
        }

       
        public override Caretaker Edit(Caretaker obj) {
            
            CaretakerRules
                .Validate(obj)
                .MaybeExplode();
            return base.Edit(obj);
            
        }


        // TODO: Decide if we need to override the Delete method inherited 
        //       from the abstract CaretakerDecorator or not.  Even if we 
        //       passed a valid Caretaker identified only by it's email 
        //       that email still might not be found by the underlying service.


        // TODO: Same decision if we need validation on Detach.  Tip: Probably
        //       not since we don't edit or create objects

        public override Notification Notify(string email, string message, Child[] children) {
            // TODO: Add validation which is only needed on the passed "message".
            //       Finish off the single rule in MessageRules.cs and use it here.

            return base.Notify(email, message, children);
        }


        // TODO: Here again do we need validation on the Retrack method?
        //       Nothing will be created/edited by the underlying service
    }
}