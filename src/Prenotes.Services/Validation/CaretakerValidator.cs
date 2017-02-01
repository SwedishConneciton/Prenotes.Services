using System.Linq;
using FluentValidation;
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        private AbstractValidator<Caretaker> CaretakerRules = new CaretakerRules();

        private AbstractValidator<string> CodeRules = new CodeRules();

        private AbstractValidator<string> MessageRules =new MessageRules();

        private AbstractValidator<Child> ChildRules =new ChildRules();
        
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


        public override Notification Notify(string email, string message, Child[] children) {
            MessageRules
                .Validate(message)
                .MaybeExplode();

            children?
                .ToList()
                .ForEach(
                    c => ChildRules
                            .Validate(c)
                            .MaybeExplode()

                );
           
            return base.Notify(email, message, children);
        }       
    }
}