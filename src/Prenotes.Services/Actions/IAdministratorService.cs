
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface IAdministratorService {

        /// <summary>
        /// Allow guest employees (one per daycare)
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Employee UseGuest(string email);

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="email"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee Add(string email, Employee employee);

        /// <summary>
        /// Remove employee
        /// </summary>
        /// <param name="email"></param>
        /// <param name="employee"></param>
        void Remove(string email, Employee employee);

        /// <summary>
        /// Grants administration rights except for the ability to grant
        /// </summary>
        /// <param name="email"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        Employee AsAdministrator(string email, Employee employee);

        /// <summary>
        /// Block an offensive or inappropriate notiication
        /// </summary>
        /// <param name="email"></param>
        /// <param name="whoami"></param>
        /// <returns></returns>
        Notification Block(string email, string whoami);

        /// <summary>
        /// Streams notifications
        /// </summary>
        /// <param name="email"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Notification[] Stream(string email, int skip, int take);
     }
}