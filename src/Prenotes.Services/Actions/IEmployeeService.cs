

using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface IEmployeeService {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Employee Confirm(string email, string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        Employee Edit(Employee obj);

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
        /// Register caretaker
        /// </summary>
        /// <param name="caretaker"></param>
        /// <param name="email"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        Handshake Register(string caretaker, string email, Child[] children);

        /// <summary>
        /// Mark a notification as offensive or inappropriate.  Decorators 
        /// could send such notifications onto administrators.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="whoami"></param>
        /// <returns></returns>
        Notification Bad(string email, string whoami);

        /// <summary>
        /// Add child to daycare
        /// </summary>
        /// <param name="email"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        Child Add(string email, Child child);

        /// <summary>
        /// Remove child from daycare which doesn't delete the child
        /// rather detaches it from the daycare
        /// </summary>
        /// <param name="email"></param>
        /// <param name="child"></param>
        void Remove(string email, Child child);

        /// <summary>
        /// All children
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Child[] Children(string email);

        /// <summary>
        /// Other employees at the same daycare
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Employee[] Others(string email);
    }
}