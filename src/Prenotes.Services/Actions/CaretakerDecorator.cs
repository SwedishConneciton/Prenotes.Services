
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public abstract class CaretakerDecorator : ICaretakerService
    {
        protected readonly ICaretakerService srv;

        public CaretakerDecorator(ICaretakerService srv) {
            this.srv = srv;
        }

        public virtual Caretaker Create(Caretaker obj) {
            return srv.Create(obj);
        }
    }
}