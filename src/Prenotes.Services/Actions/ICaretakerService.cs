
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
        /// Edit the caretaker except the email property
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Caretaker Edit(Caretaker obj);

        /// <summary>
        /// Wipe out the caretaker completely.  Every user
        /// will have the right to blow away everything about 
        /// themselves except for notifications they have created.
        /// </summary>
        /// <param name="email"></param>
        void Nuke(string email);

        /// <summary>
        /// Notify for one or more children
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        Notification Notify(string email, string message, Child[] children);

        /// <summary>
        /// Reply to a message
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <param name="whoami"></param>
        /// <returns></returns>
        Notification Reply(string email, string message, string whoami);

        /// <summary>
        /// Retract a notification
        /// </summary>
        /// <param name="email"></param>
        /// <param name="whoami"></param>
        /// <returns></returns>
        Notification Retract(string email, string whoami);

        /// <summary>
        /// Streams notifications
        /// </summary>
        /// <param name="email"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Notification[] Stream(string email, int skip, int take);

        /// <summary>
        /// Mark notification as read
        /// </summary>
        /// <param name="email"></param>
        /// <param name="whoami"></param>
        /// <returns></returns>
        Notification Read(string email, string whoami);

        /// <summary>
        /// Grab children associated to the caretaker
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Child[] Children(string email);
    }
}