
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface ICaretakerService {

        /// <summary>
        /// Confirms the confirmation code and persists the
        /// Caretaker if necessary attaching them to a child
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Caretaker Confirm(Caretaker obj, string code);


        /// <summary>
        /// Edit the caretaker even letting the service change the email
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Caretaker Edit(Caretaker obj);

        /// <summary>
        /// Detach then wipe out the caretaker
        /// </summary>
        /// <param name="obj"></param>
        void Delete(Caretaker obj);

        /// <summary>
        /// Drop relation to a child
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="child"></param>
        void Detach(Caretaker obj, Child child);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Notification Notify(Notification obj, Child[] children);

        /// <summary>
        /// Retrack a notification
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Notification Retrack(Notification obj);
    }
}