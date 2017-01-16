
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface ICaretakerService {

        /// <summary>
        /// Confirms the confirmation code and persists the
        /// Caretaker 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Caretaker Confirm(Caretaker obj, int code);
    }
}