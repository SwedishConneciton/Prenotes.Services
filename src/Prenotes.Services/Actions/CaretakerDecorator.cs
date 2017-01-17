
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public abstract class CaretakerDecorator : ICaretakerService
    {
        protected readonly ICaretakerService srv;

        public CaretakerDecorator(ICaretakerService srv) {
            this.srv = srv;
        }

        /// <remarks>The method is marked as virtual to indicate that it should be overriden</remarks>
        public virtual Caretaker Confirm(Caretaker obj, string code) {
            return srv.Confirm(obj, code);
        }

        public virtual void Delete(Caretaker obj)
        {
            srv.Delete(obj);
        }

        public virtual void Detach(Caretaker obj, Child child)
        {
            srv.Detach(obj, child);
        }

        public virtual Caretaker Edit(Caretaker obj)
        {
            return srv.Edit(obj);
        }

        public virtual Notification Notify(Notification obj, Child[] children)
        {
            return srv.Notify(obj, children);
        }

        public virtual Notification Retrack(Notification obj)
        {
            return srv.Retrack(obj);
        }
    }
}