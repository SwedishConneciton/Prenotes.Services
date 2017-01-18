
namespace Prenotes.Services.Things {

    public class Employee : User {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="created"></param>
        /// <param name="name"></param>
        public Employee(string email, long created, string name): base(email, created, name) {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        public Employee(string email): base(email) {

        }
    }
}