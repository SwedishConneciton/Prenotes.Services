
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public abstract class CaretakerDecorator : ICaretakerService
    {
        protected readonly ICaretakerService srv;

        public CaretakerDecorator(ICaretakerService srv) {
            this.srv = srv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>The method is marked as virtual to indicate that it should be overriden</remarks>
        /// <param name="obj"></param>
        /// <param name="shake"></param>
        /// <returns></returns>
        public virtual Caretaker Create(Caretaker obj, Handshake shake) {
            return srv.Create(obj, shake);
        }
    }
}