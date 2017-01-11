
using Prenotes.Services.Actions;
using Prenotes.Services.Things;

namespace Prenotes.Services.Validation {

    public class CaretakerValidator : CaretakerDecorator {
        
        public CaretakerValidator(ICaretakerService srv): base(srv) {

        }

        public override Caretaker Create(Caretaker obj, Employee creator) {
            return base.Create(obj, creator);    
        }
    }
}