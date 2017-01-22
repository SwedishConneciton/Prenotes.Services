
using Prenotes.Services.Things;

namespace Prenotes.Services.Actions {

    public interface ISuperService {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        Daycare Add(string email, Daycare obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="obj"></param>
        void Remove(string email, Daycare obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="obj"></param>
        /// <param name="employee"></param>
        void Assign(string email, Daycare obj, Employee employee);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="obj"></param>
        /// <param name="employee"></param>
        void Drop(string email, Daycare obj, Employee employee);


        /// <summary>
        /// Streams notifications
        /// </summary>
        /// <param name="email"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Notification[] Stream(string email, int skip, int take);

        /// <summary>
        /// Pull daycare sites
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Daycare[] Sites(string email, int skip, int take);

        /// <summary>
        /// Administrators by daycare
        /// </summary>
        /// <param name="email"></param>
        /// <param name="daycare"></param>
        /// <returns></returns>
        Employee[] Administrators(string email, Daycare daycare);
    }
}