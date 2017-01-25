
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public abstract class CaretakerDecorator : ICaretakerService
    {
        protected readonly ICaretakerService srv;

        public CaretakerDecorator(ICaretakerService srv) {
            this.srv = srv;
        }

        /// <remarks>The method is marked as virtual to indicate that it should be overriden</remarks>
        public virtual Caretaker Confirm(string email, string code) {
            return srv.Confirm(email, code);
        }

        public virtual void Nuke(string email)
        {
            srv.Nuke(email);
        }

        public virtual Caretaker Edit(Caretaker obj)
        {
            return srv.Edit(obj);
        }

        public virtual Notification Notify(string email, string message, Child[] children)
        {
            return srv.Notify(email, message, children);
        }

        public virtual Notification Reply(string email, string message, string whoami)
        {
            return srv.Reply(email, message, whoami);
        }

        public virtual Notification Retract(string email, string whoami)
        {
            return srv.Retract(email, whoami);
        }

        public virtual Notification[] Stream(string email, int skip, int take) {
            return srv.Stream(email, skip, take);
        }

        public virtual Notification Read(string email, string whoami) {
            return srv.Read(email, whoami);
        }

        public virtual Child[] Children(string email)
        {
            return srv.Children(email);
        }
    }
}